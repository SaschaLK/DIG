using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminTools : MonoBehaviour {

    public void ClearOres() {
        PlayerPrefs.DeleteAll();
        StoreController.instance.WriteStoreHome();
    }

    public void AddOres(string oreType) {
        PlayerPrefs.SetInt(oreType, PlayerPrefs.GetInt(oreType) + 50);
        StoreController.instance.UpdateInventory();
        StoreController.instance.WriteStoreHome();
    }
}
