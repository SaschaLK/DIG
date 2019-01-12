using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PouchBehaviour : MonoBehaviour {

    public static PouchBehaviour instance;

    public GameObject oreValueText;

    [HideInInspector]
    public int ironOreCount;
    private List<string> oreTypeNames = new List<string>();

    private void Awake() {
        instance = this;
    }

    private void Start() {
        //Setting ore Text Value for Store on Scene Load; including game loop.
        SceneManager.sceneLoaded += RefreshOreText;
        SetOreText();

        //Get List of all types of ores.
        foreach(GameObject oreType in MapGeneratorBehaviour.instance.oreTypes) {
            oreTypeNames.Add(oreType.name);
        }
    }

    private void RefreshOreText(Scene scene, LoadSceneMode mode) {
        SetOreText();
    }

    public void AddOre(string oreTag) {
        switch (oreTag) {
            case "Iron":
                ironOreCount++;
                break;
            case "Gold":
                break;
        }
    }

    private void SetOreText() {
        oreValueText = GameObject.FindGameObjectWithTag("OreStoreTextValue");

        oreValueText.GetComponent<Text>().text = "Iron Ore: " + ironOreCount.ToString();
    }
}
