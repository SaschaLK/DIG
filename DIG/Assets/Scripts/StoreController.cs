using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour {
    public static StoreController instance;

    public GameObject storeHome;
    public Text inventoryText;
    public GameObject storeHullUpgrades;
    public GameObject storeGasUpgrades;
    public GameObject storeEngineUpgrades;
    public GameObject storeDrillUpgrades;

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    private void Awake() {
        instance = this;
    }

    private void Start() {
        SetInventory();
        WriteStoreHome();
    }

    public void SetInventory() {
        foreach (Ore ore in OreGenerator.instance.ores) {
            inventory.Add(ore.oreObject.name, PlayerPrefs.GetInt(ore.oreObject.name));
        }
    }

    public void UpdateInventory() {
        foreach(string key in inventory.Keys) {
            inventory[key] = PlayerPrefs.GetInt(key);
        }
    }

    public void WriteStoreHome() {
        string text = "";
        foreach (string ore in inventory.Keys) {
            if(inventory[ore] != 0) {
                text += ore + ": " + inventory[ore] + "\n";
            }
        }
        inventoryText.text = text;
    }

    public void SelectShopHome() {
        storeHome.SetActive(true);
        storeHullUpgrades.SetActive(false);
        storeGasUpgrades.SetActive(false);
        storeEngineUpgrades.SetActive(false);
        storeDrillUpgrades.SetActive(false);
    }

    public void SelectUpgradePanel(GameObject panel) {
        storeHome.SetActive(false);
        panel.SetActive(true);
    }
}

