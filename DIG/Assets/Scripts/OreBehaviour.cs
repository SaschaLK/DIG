using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreBehaviour : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        PouchBehaviour.instance.AddOre(tag);
        gameObject.SetActive(false);
    }
}
