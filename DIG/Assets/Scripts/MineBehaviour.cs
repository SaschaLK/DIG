using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        GasBehaviour.instance.ChangeGas(-0.1f);
        gameObject.SetActive(false);
    }
}
