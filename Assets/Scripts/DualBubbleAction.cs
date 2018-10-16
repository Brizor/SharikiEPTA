using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualBubbleAction : MonoBehaviour {
    public GameManager gameManager;
    [SerializeField] GameObject prefabBubble;
    [SerializeField] GameObject badBubblePrefab;
    private int type;
    private float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UpLine")
        {
            gameManager.bubbleCollision(type);
            Destroy(this.gameObject);
        }

    }

    private void OnMouseUp()
    {
        GameObject newBubble = null;
        GameObject newBubble2 = null;
        if (Time.timeScale != 0)
        {
                newBubble = Instantiate(prefabBubble, new Vector3(-0.1f + this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
                newBubble.GetComponent<BubbleMove>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().type = 0;

                newBubble2 = Instantiate(badBubblePrefab, new Vector3(0.1f + this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
                newBubble2.GetComponent<BubbleMove>().gameManager = this.gameManager;
                newBubble2.GetComponent<ActionsWithBubbles>().gameManager = this.gameManager;
                newBubble2.GetComponent<ActionsWithBubbles>().type = 1;

            
            gameManager.shellReaction();
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        speed = gameManager.speed;
        type = 3;
    }

    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
