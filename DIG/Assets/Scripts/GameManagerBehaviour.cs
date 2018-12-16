using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour {

    public static GameManagerBehaviour instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        
    }

    public void EmptyGas() {
        SceneManager.LoadScene("MainDig");
    }
}
