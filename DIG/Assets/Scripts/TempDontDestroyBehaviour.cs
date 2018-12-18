using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempDontDestroyBehaviour : MonoBehaviour {

    private Text text;

    private void Start() {
        text = GetComponent<Text>();
        text.text = "Iron: " + GameManagerBehaviour.instance.ironOreCount.ToString();
    }
}
