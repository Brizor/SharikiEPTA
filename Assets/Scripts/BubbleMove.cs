using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour {

    public GameManager gameManager;

    public float speed;

    private void Awake()
    {
        
    }
    void Start () {

        speed = gameManager.speed;
	}

	void Update () {
        transform.position += new Vector3(0,  -speed * Time.deltaTime, 0);
	}
}
