using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopGasController : MonoBehaviour {

    public List<GameObject> tanks = new List<GameObject>();
    public Button next;
    public Button previous;
    private int currentTank = 0;

    [Serializable]
    public struct Price {
        [SerializeField] public int iron;
        [SerializeField] public int gold;
        [SerializeField] public int diamond;
        [SerializeField] public int endCrystal;
    }

    [Header("Tier 1")]
    public Price priceT1;
    public Button tier1Unlock;
    public Toggle tier1Equip;

    [Header("Tier 2")]
    public Price priceT2;
    public Button tier2Unlock;
    public Toggle tier2Equip;

    [Header("Tier 3")]
    public Price priceT3;
    public Button tier3Unlock;
    public Toggle tier3Equip;

    [Header("Tier 4")]
    public Price priceT4;
    public Button tier4Unlock;
    public Toggle tier4Equip;

    private void Start() {
        SetPage();
    }

    private bool CheckPrices(Price price) {
        if(PlayerPrefs.GetInt("Iron") >= price.iron && PlayerPrefs.GetInt("Gold") >= price.gold && PlayerPrefs.GetInt("Diamond") >= price.diamond && PlayerPrefs.GetInt("EndCrystal") >= price.endCrystal) {
            return true;
        }
        else {
            return false;
        }
    }

    public void SetPage() {
        //Check if already unlocked
        if (PlayerPrefs.GetInt("gt1") == 1) {
            tier1Unlock.gameObject.SetActive(false);
            tier1Equip.gameObject.SetActive(true);
        }
        else {
            //Unlock button interactable via price
            if (CheckPrices(priceT1)) {
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
            if (CheckPrices(priceT2)) {
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
            if (CheckPrices(priceT3)) {
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
            if (CheckPrices(priceT4)) {
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

    public void ChangeShownTank(int factor) {
        tanks[currentTank].SetActive(false);
        currentTank += factor;
        tanks[currentTank].SetActive(true);

        if (currentTank == 0) {
            previous.interactable = false;
        }
        else {
            previous.interactable = true;
        }

        if(currentTank == tanks.Count - 1) {
            next.interactable = false;
        }
        else {
            next.interactable = true;
        }
    }
}


