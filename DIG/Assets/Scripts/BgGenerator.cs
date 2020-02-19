using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgGenerator : MonoBehaviour {

    public GameObject bgRow;

    private void Start() {
        for(int i = -14; i < 15; i++) {
            Instantiate(bgRow, new Vector3(0, i, 0), Quaternion.identity);
        }
    }
}
