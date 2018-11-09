using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlotManager : MonoBehaviour {
    [SerializeField] Sprite[] sprites;
	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, sprites.Length);
        this.GetComponent<SpriteRenderer>().sprite = sprites[rand];
        
    }

    private void destroing()
    {
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
