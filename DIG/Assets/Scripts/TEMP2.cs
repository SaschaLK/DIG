using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEMP2 : MonoBehaviour {

    private Button button;

    private void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(GameManagerBehaviour.instance.StartDig);
    }


}
