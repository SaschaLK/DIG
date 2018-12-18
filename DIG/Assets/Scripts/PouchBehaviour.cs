using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchBehaviour : MonoBehaviour {

    public static PouchBehaviour instance;

    [HideInInspector]
    public int ironOreCount;

    private void Awake() {
        instance = this;
    }

    public void AddOre(string oreTag) {
        switch (oreTag) {
            case "Iron":
                break;
            case "Gold":
                break;
        }
    }
}
