using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GovnoScript : MonoBehaviour {
    [SerializeField] BubbleManager BubbleMan;

    private void BubbleManagerOn()
    {
        BubbleMan.gameObject.SetActive(true);
    }
}
