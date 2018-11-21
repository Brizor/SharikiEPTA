using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsWithBubbles : MonoBehaviour {
    [SerializeField] GameObject blot;
    public GameManager gameManager;
    [SerializeField] GameObject particleEfect;
    private Color color;

    public int type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UpLine")
        {
            gameManager.tapsToCreate--;
            gameManager.bubbleCollision(type);
            var main = Instantiate(particleEfect, new Vector3(transform.position.x, transform.position.y, 3f), transform.rotation).GetComponent<ParticleSystem>().main;
            main.startColor = color;
            Destroy(this.gameObject);
        }
    }

    private void blotsCreate()
    {
        Instantiate(blot, new Vector3 (transform.position.x,transform.position.y, 3f), transform.rotation).GetComponent<SpriteRenderer>().color = color;
        var main = Instantiate(particleEfect, new Vector3(transform.position.x, transform.position.y, 3f), transform.rotation).GetComponent<ParticleSystem>().main;
        main.startColor = color;
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
        if (type == 0)
        {
            color = new Color(0.3960784f, 0.7843725f, 0.9921569f);
        }
        else if (type == 1)
        {
            color = new Color(1, 0.3726415f, 0.3726415f);
        }
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
