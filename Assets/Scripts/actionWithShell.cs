using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionWithShell : MonoBehaviour {

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
        gameManager.tapsToCreate--;
        GameObject newBubble = null;
        if (Time.timeScale != 0)
        {
            int what = Random.Range(0, 2);
            if (what == 0)
            {
                newBubble = Instantiate(prefabBubble, this.transform.position, transform.rotation);
                newBubble.GetComponent<BubbleMove>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().type = 0;

            }
            if (what == 1)
            {
                newBubble = Instantiate(badBubblePrefab, this.transform.position, transform.rotation);
                
                newBubble.GetComponent<BubbleMove>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().type = 1;

            }
            gameManager.shellReaction();
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        gameManager.tapsToCreate++;
        speed = gameManager.speed;
        type = 2;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            Destroy(this.gameObject);
        }
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
