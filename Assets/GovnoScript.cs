using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GovnoScript : MonoBehaviour {
    [SerializeField] BubbleManager BubbleMan;

    private void BubbleManagerOnOff()
    {
        BubbleMan.gameObject.SetActive(true);
    }
}
