using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerController : MonoBehaviour {

    public Slider rightSlider;
    public Slider leftSlider;

    public float minimumSpeed;
    public float horizontalMsAmplifier;
    public float verticalMsAmplifier;
    public float horizontalToVerticalImpact;

    [HideInInspector]
    public float rightPowerSliderInput;
    [HideInInspector]
    public float leftPowerSliderInput;

    private float verticalMs;
    private float horizontalMs;

    private void Start() {
        rightSlider.onValueChanged.AddListener(delegate { SetRightPower(rightSlider.value); });
        leftSlider.onValueChanged.AddListener(delegate { SetLeftPower(leftSlider.value); });
    }

    private void Update() {
        MoveMinerDown();
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

        transform.Translate(horizontalMs, -verticalMs, 0);
    }

    public void SetRightPower(float power) {
        rightPowerSliderInput = power;
    }

    public void SetLeftPower(float power) {
        leftPowerSliderInput = power;
    }
}
