using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWithUpLine : MonoBehaviour {

    [SerializeField] GameManager gameManager;

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bubble")
        {
            gameManager.badReaction();
            Destroy(collision.gameObject);
        }

        if(collision.tag == "BadBubble")
        {
            Destroy(collision.gameObject);
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Conveyor")
        {
            Destroy(collision.gameObject);
        }
    }

    void Start () {
		
	}

	void Update () {
		
	}
}
