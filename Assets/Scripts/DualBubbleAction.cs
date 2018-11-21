using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualBubbleAction : MonoBehaviour {
    public GameManager gameManager;
    [SerializeField] GameObject prefabBubble;
    [SerializeField] GameObject badBubblePrefab;
    [SerializeField] GameObject particleEfect;
    public int type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UpLine")
        {
            gameManager.tapsToCreate -= 3;
            var main = Instantiate(particleEfect, new Vector3(transform.position.x, transform.position.y, 3f), transform.rotation).GetComponent<ParticleSystem>().main;
            main.startColor = new Color(1f, 0.4941176f, 0.9453598f,1f);
            gameManager.bubbleCollision(type);
            Destroy(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        gameManager.tapsToCreate--;
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
        gameManager.tapsToCreate += 2;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
