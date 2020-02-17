using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreBehaviour : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        string oreName = name.Substring(0, name.Length - 7);
        PlayerPrefs.SetInt(oreName, PlayerPrefs.GetInt(oreName) + 1);
        gameObject.SetActive(false);
    }
}
