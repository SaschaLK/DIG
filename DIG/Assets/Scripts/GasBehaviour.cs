using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBehaviour : MonoBehaviour {

    public static GasBehaviour instance;

    public float baseGasConsumptionRate;

    [HideInInspector]
    public float gasComsumptionRate;
    [HideInInspector]
    public bool isDigging;

    private Slider slider;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        slider = transform.GetComponent<Slider>();
    }

    private void Update() {
        if (isDigging) {
            slider.value -= Time.deltaTime * (baseGasConsumptionRate + gasComsumptionRate);
            if(slider.value <= 0) {
                GameManagerBehaviour.instance.EmptyGas();
            }
        }
    }

    public void ChangeGas(float gasChange) {
        slider.value += gasChange;
    }
}
