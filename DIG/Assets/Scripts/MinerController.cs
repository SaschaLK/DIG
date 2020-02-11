using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerController : MonoBehaviour {

    public static MinerController instance;
    
    public Slider rightSlider;
    public Slider leftSlider;

    public float minimumSpeed;
    public float horizontalMsAmplifier;
    public float verticalMsAmplifier;
    public float horizontalToVerticalImpact;

    public Transform minerSprite;

    [HideInInspector]
    public bool isDigging;
    [HideInInspector]
    public float rightPowerSliderInput;
    [HideInInspector]
    public float leftPowerSliderInput;

    private float verticalMs;
    private float horizontalMs;
    private float gasConsumption;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        rightSlider.onValueChanged.AddListener(delegate { SetRightPower(rightSlider.value);
            gasConsumption = (rightSlider.value + leftSlider.value) / 100;
        });
        leftSlider.onValueChanged.AddListener(delegate { SetLeftPower(leftSlider.value);
            gasConsumption = (rightSlider.value + leftSlider.value) / 100;
        });
    }

    private void Update() {
        if (isDigging) {
            MoveMinerDown();
        }
        if(gasConsumption != 0) {
            ConsumeGas();
        }
    }

    private void MoveMinerDown() {
        //Get value from horizontal input and use it to determine the vertical speed
        verticalMs = (rightPowerSliderInput / horizontalToVerticalImpact) + (leftPowerSliderInput / horizontalToVerticalImpact);
        verticalMs *= Time.deltaTime * verticalMsAmplifier;

        //minimum verticalMs
        verticalMs += minimumSpeed;

        //Get value from horizontal input and use it to determine the horizontal direction
        horizontalMs = rightPowerSliderInput - leftPowerSliderInput;
        horizontalMs *= Time.deltaTime * horizontalMsAmplifier;
        minerSprite.rotation = new Quaternion(0, 0, horizontalMs*10, 1);
        Debug.Log(horizontalMs * 10);

        transform.Translate(horizontalMs, -verticalMs, 0);
    }

    private void ConsumeGas() {
        GasBehaviour.instance.gasComsumptionRate = gasConsumption;
    }

    public void SetRightPower(float power) {
        rightPowerSliderInput = power;
    }

    public void SetLeftPower(float power) {
        leftPowerSliderInput = power;
    }
}
