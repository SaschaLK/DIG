using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerController : MonoBehaviour {

    public Slider rightSlider;
    public Slider leftSlider;

    public float horizontalMsAmplifier;
    public float verticalMsAmplifier;
    public float horizontalToVerticalDevider;

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
        //verticalMs = (Input.GetAxis("HorizontalRight") / horizontalToVerticalDevider) + (Input.GetAxis("HorizontalLeft") / horizontalToVerticalDevider);
        verticalMs = (rightPowerSliderInput / horizontalToVerticalDevider) + (leftPowerSliderInput / horizontalToVerticalDevider);
        verticalMs *= Time.deltaTime * verticalMsAmplifier;

        //Get value from horizontal input and use it to determine the horizontal direction
        //horizontalMs = Input.GetAxis("HorizontalRight") - Input.GetAxis("HorizontalLeft");
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
