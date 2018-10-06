using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWithButtomLine : MonoBehaviour {
    [SerializeField] GameObject prefabConveyor;
    [SerializeField] GameManager gameManager;

    private Transform conveyorPos;

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject conv = null;
        conveyorPos = collision.gameObject.transform;
        if(collision.tag == "Conveyor")
        {
           conv = Instantiate(prefabConveyor,new Vector3(conveyorPos.position.x,-9.1f ,1f), conveyorPos.rotation);
            conv.GetComponent<Conveyor>().gameManager = this.gameManager;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
