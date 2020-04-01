using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerGasController : MonoBehaviour {
    public static MinerGasController instance;

    [SerializeField] private Slider gasSlider;
    [SerializeField] private float baseGasConsumption;
    [SerializeField] private GameObject fgSlider;
    [SerializeField] private GameObject bgSlider;
    private float gasConsumption;

    public bool isDigging;


    private void Awake() {
        instance = this;
    }

    private void Update() {
        if (isDigging) {
            gasSlider.value -= Time.deltaTime * (baseGasConsumption + gasConsumption);
            if(gasSlider.value <= 0) {
                GameManagerBehaviour.instance.EmptyGas();
            }
        }
    }

    public void ChangeGas(float gasChange) {
        gasSlider.value += gasChange;
    }

    //GasConsumption for sliders;
    public void ChangeGasConsumption(float consumption) {
        gasConsumption = consumption;
    }

    //Continuous gas consumption
    public void AddBaseGasConsumption(float consumption) {
        baseGasConsumption += consumption;
    }

    public void AddTankSize(float tank) {
        gasSlider.maxValue += tank;
        gasSlider.value = gasSlider.maxValue;

        if(tank > 0) {
            fgSlider.GetComponent<RectTransform>().anchorMax = new Vector2(tank / 10, 1);
        }
        else {
            fgSlider.GetComponent<RectTransform>().anchorMax = new Vector2(0.05f, 1);
        }
        //bgSlider.GetComponent<RectTransform>().anchorMax = new Vector2(tank / 10, 1);
    }

}
