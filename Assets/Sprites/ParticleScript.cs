using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

    private void Destroying()
    {
        Destroy(this.gameObject);
    }
	// Use this for initialization
	void Start () {
        Invoke("Destroying", 1);

    }
}
