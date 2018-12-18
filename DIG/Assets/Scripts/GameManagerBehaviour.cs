using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour {

    public static GameManagerBehaviour instance;

    public GameObject shopPanel;
    public Slider[] powerSliders;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        foreach(Slider slider in powerSliders) {
            slider.gameObject.SetActive(false);
        }
        GasBehaviour.instance.isDigging = false;
        MinerController.instance.isDigging = false;

        //Temp until pouch behaviour is reimplemented
        ironPouchValue.text = "Iron: " + ironOreCount.ToString();
    }

    public void StartDig() {
        ChangeSliderInteractable();
        shopPanel.SetActive(false);
        GasBehaviour.instance.isDigging = true;
        MinerController.instance.isDigging = true;
    }

    public void EmptyGas() {
        ChangeSliderInteractable();
        GasBehaviour.instance.isDigging = false;
        MinerController.instance.isDigging = false;
        shopPanel.SetActive(true);
        SceneManager.LoadScene("MainDig");
    }

    private void ChangeSliderInteractable() {
        foreach(Slider slider in powerSliders) {
            slider.gameObject.SetActive(!slider.gameObject.activeSelf);
        }
    }

    public void LoadShit() {
        //Temp functions for presentation. TO DO: ACTUAL SINGLETON IMPLEMENTATION!
        if (shopPanel == null) {
            shopPanel = GameObject.Find("ShopPanel");
            powerSliders[0] = GameObject.Find("LeftPower").GetComponent<Slider>();
            powerSliders[1] = GameObject.Find("RightPower").GetComponent<Slider>();
            ironPouchValue = GameObject.Find("Iron").GetComponent<Text>();
        }
    }


    //Temp aus pouch behaviour

    public Text ironPouchValue;
    public int ironOreCount;
    private int goldOreCount;

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
}
