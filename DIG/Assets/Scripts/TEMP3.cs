using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP3 : MonoBehaviour {

    public static TEMP3 instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
