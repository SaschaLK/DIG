using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreBehaviour : MonoBehaviour {

    private void Awake() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameManagerBehaviour.instance.AddOre(tag);
        //PouchBehaviour.instance.AddOre(tag);
        gameObject.SetActive(false);
    }
}
