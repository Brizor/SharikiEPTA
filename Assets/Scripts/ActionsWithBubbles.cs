using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsWithBubbles : MonoBehaviour {
    [SerializeField] GameObject blot;
    public GameManager gameManager;

    public int type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UpLine")
        {
            gameManager.tapsToCreate--;//new
            gameManager.bubbleCollision(type);
            Destroy(this.gameObject);
        }
    }

    private void blotsCreate()
    {
        if (type == 0)
        {
            Instantiate(blot, new Vector3 (transform.position.x,transform.position.y, 3f), transform.rotation).GetComponent<SpriteRenderer>().color = new Color(0.3960784f, 0.7843725f, 0.9921569f);
        }
        else if (type == 1)
        {
            Instantiate(blot, new Vector3(transform.position.x, transform.position.y, 3f), transform.rotation).GetComponent<SpriteRenderer>().color = new Color(1, 0.3726415f, 0.3726415f);
        }
    }

    private void OnMouseUp()
    {
        if (Time.timeScale != 0)
        {
            gameManager.tapsToCreate--;//new
            gameManager.destroyBubbleReaction(type);
            blotsCreate();
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
