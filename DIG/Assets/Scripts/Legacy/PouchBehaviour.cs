using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PouchBehaviour : MonoBehaviour {

    public static PouchBehaviour instance;

    public GameObject oreValueText;

    private int ironOreCount;
    private List<int> oreCounts = new List<int>();
    private List<string> oreTypeNames = new List<string>();

    private void Awake() {
        instance = this;
    }

    private void Start() {
        //Get List of all types of ores.
        foreach(Ore oreType in OreGenerator.instance.ores) {
            oreTypeNames.Add(oreType.oreObject.name);
        }
    }

    public void AddOre(string oreName) {
        PlayerPrefs.SetInt(oreName, PlayerPrefs.GetInt(oreName) + 1);
    }
}
