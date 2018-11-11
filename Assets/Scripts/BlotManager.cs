using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlotManager : MonoBehaviour {
    [SerializeField] Sprite[] sprites;

	void Start () {
        int rand = Random.Range(0, sprites.Length);
        this.GetComponent<SpriteRenderer>().sprite = sprites[rand];
    }

    private void destroing()
    {
        Destroy(this.gameObject);
    }
}
