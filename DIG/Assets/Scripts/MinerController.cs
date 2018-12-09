using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerController : MonoBehaviour {

    public float horizontalMsAmplifier;
    public float verticalMsAmplifier;
    public float horizontalToVerticalDevider;

    private float verticalMs;
    private float horizontalMs;

    private void Update() {
        MoveMinerDown();
    }

    private void MoveMinerDown() {
        //Get value from horizontal input and use it to determine the vertical speed
        verticalMs = (Input.GetAxis("HorizontalRight") / horizontalToVerticalDevider) + (Input.GetAxis("HorizontalLeft") / horizontalToVerticalDevider);
        verticalMs *= Time.deltaTime * verticalMsAmplifier;

        //Get value from horizontal input and use it to determine the horizontal direction
        horizontalMs = Input.GetAxis("HorizontalRight") - Input.GetAxis("HorizontalLeft");
        horizontalMs *= Time.deltaTime * horizontalMsAmplifier;

        transform.Translate(horizontalMs, -verticalMs, 0);
    }
}
