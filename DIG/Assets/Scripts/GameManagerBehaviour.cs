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
        instance = this;
    }

    private void Start() {
        foreach(Slider slider in powerSliders) {
            slider.gameObject.SetActive(false);
        }
        GasBehaviour.instance.isDigging = false;
        MinerController.instance.isDigging = false;

    }

    public void StartDig() {
        ChangeSliderInteractable();
        shopPanel.SetActive(false);
        GasBehaviour.instance.isDigging = true;
        MinerController.instance.isDigging = true;
    }

    public void EmptyGas() {
        SceneManager.LoadScene("MainDig");
    }

    private void ChangeSliderInteractable() {
        foreach(Slider slider in powerSliders) {
            slider.gameObject.SetActive(!slider.gameObject.activeSelf);
        }
    }
}
