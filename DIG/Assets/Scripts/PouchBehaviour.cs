using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchBehaviour : MonoBehaviour {

    public static PouchBehaviour instance;

    [HideInInspector]
    public int ironOreCount;

    private List<string> oreTypeNames = new List<string>();

    private void Awake() {
        instance = this;
        if(GameObject.FindGameObjectsWithTag("Pouch").Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance);
    }

    private void Start() {
        //Get List of all types of ores.
        foreach(GameObject oreType in MapGeneratorBehaviour.instance.oreTypes) {
            oreTypeNames.Add(oreType.name);
        }
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
