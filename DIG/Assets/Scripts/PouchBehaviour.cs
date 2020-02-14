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
        ironOreCount = PlayerPrefs.GetInt("Iron");

        //Get List of all types of ores.
        foreach(Ore oreType in OreGenerator.instance.ores) {
            oreTypeNames.Add(oreType.oreObject.name);
        }

        //Setting ore Text Value for Store on Scene Load; including game loop.
        SceneManager.sceneLoaded += RefreshOreText;
        SetOreText();
    }

    private void RefreshOreText(Scene scene, LoadSceneMode mode) {
        SetOreText();
    }

    public void AddOre(string oreName) {
        PlayerPrefs.SetInt(oreName, PlayerPrefs.GetInt(oreName) + 1);
    }

    private void SetOreText() {
        oreValueText = GameObject.FindGameObjectWithTag("OreStoreTextValue");
        string text = "";
        foreach(string ore in oreTypeNames) {
            text += ore + ": " + PlayerPrefs.GetInt(ore) + "\n";
        }
        PlayerPrefs.SetInt("Iron", ironOreCount);
        oreValueText.GetComponent<Text>().text = text;
    }
}
