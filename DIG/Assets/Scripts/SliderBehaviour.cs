using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderBehaviour : MonoBehaviour, IBeginDragHandler, IEndDragHandler {

    public float cooldownDelay;
    public float cooldownRate;

    private Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        StopAllCoroutines();
    }

    public void OnEndDrag(PointerEventData eventData) {
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSecondsRealtime(cooldownDelay);
        float timeSlice = (slider.value / cooldownRate);
        while (slider.value >= 0) {
            slider.value -= timeSlice;
            yield return new WaitForFixedUpdate();
            if(slider.value <= 0) {
                break;
            }
        }
    }
}
