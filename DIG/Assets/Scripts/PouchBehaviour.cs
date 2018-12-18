using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouchBehaviour : MonoBehaviour {

    public static PouchBehaviour instance;

    public Text ironPouchValue;
    private int ironOreCount;
    private int goldOreCount;

    private void Awake() {
        instance = this;
    }

    public void AddOre(string oreTag) {
        switch (oreTag) {
            case "Iron":
                ironOreCount++;
                ironPouchValue.text = "Iron: " + ironOreCount.ToString();

                break;
            case "Gold":
                goldOreCount++;
                break;
        }
    }

    public void LoadShit() {
        if (ironPouchValue == null) {
            Debug.Log("Hello");
            ironPouchValue = GameObject.Find("Iron").GetComponent<Text>();
        }
    }
}
