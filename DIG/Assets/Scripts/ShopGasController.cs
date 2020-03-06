using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopGasController : MonoBehaviour {
    //[Serializable]
    //public struct UnlockButton {
    //    public Button button;
    //    public Toggle toggle;
    //    [Serializable]
    //    public struct UnlockValue {
    //        public string name;
    //        public int value;
    //    }
    //    public List<UnlockValue> unlockValues;
    //}

    //public List<UnlockButton> buttons = new List<UnlockButton>();

    public Button tier1Unlock;
    public Toggle tier1Equip;
    public Button tier2Unlock;
    public Toggle tier2Equip;
    public Button tier3Unlock;
    public Toggle tier3Equip;
    public Button tier4Unlock;
    public Toggle tier4Equip;

    private void Start() {
        SetPage();
    }

    public void SetPage() {
        if (PlayerPrefs.GetInt("gt1") == 1) {
            tier1Unlock.gameObject.SetActive(false);
            tier1Equip.gameObject.SetActive(true);
        }
        else {
            if (PlayerPrefs.GetInt("Iron") > 20) {
                tier1Unlock.interactable = true;
            }
            else {
                tier1Unlock.interactable = false;
            }
        }

        if (PlayerPrefs.GetInt("gt2") == 1) {
            tier2Unlock.gameObject.SetActive(false);
            tier2Equip.gameObject.SetActive(true);
        }
        else {
            if (PlayerPrefs.GetInt("Gold") > 20) {
                tier2Unlock.interactable = true;
            }
            else {
                tier2Unlock.interactable = false;
            }
        }

        if (PlayerPrefs.GetInt("gt3") == 1) {
            tier3Unlock.gameObject.SetActive(false);
            tier3Equip.gameObject.SetActive(true);
        }
        else {
            if (PlayerPrefs.GetInt("Diamond") > 20) {
                tier3Unlock.interactable = true;
            }
            else {
                tier3Unlock.interactable = false;
            }
        }

        if (PlayerPrefs.GetInt("gt4") == 1) {
            tier4Unlock.gameObject.SetActive(false);
            tier4Equip.gameObject.SetActive(true);
        }
        else {
            if (PlayerPrefs.GetInt("EndCrystal") > 20) {
                tier4Unlock.interactable = true;
            }
            else {
                tier4Unlock.interactable = false;
            }
        }



    }

    public void HideUnlock(string tier) {
        switch (tier) {
            case "gt1":
                tier1Unlock.gameObject.SetActive(false);
                tier1Equip.gameObject.SetActive(true);
                PlayerPrefs.SetInt("gt1", 1);
                break;

            case "gt2":
                tier2Unlock.gameObject.SetActive(false);
                tier2Equip.gameObject.SetActive(true);
                PlayerPrefs.SetInt("gt2", 1);
                break;

            case "gt3":
                tier3Unlock.gameObject.SetActive(false);
                tier3Equip.gameObject.SetActive(true);
                PlayerPrefs.SetInt("gt3", 1);
                break;

            case "gt4":
                tier4Unlock.gameObject.SetActive(false);
                tier4Equip.gameObject.SetActive(true);
                PlayerPrefs.SetInt("gt4", 1);
                break;
        }
    }

    public void SetEquip() {

    }

}
