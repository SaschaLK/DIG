using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour {
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        MinerGasController.instance.ChangeGas(damage);
        gameObject.SetActive(false);
    }
}
