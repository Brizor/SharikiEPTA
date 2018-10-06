using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsWithBubbles : MonoBehaviour {

    public GameManager gameManager;
    public int type;

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
        if (Time.timeScale != 0)
        {
            gameManager.destroyBubbleReaction(type);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
    }

}
