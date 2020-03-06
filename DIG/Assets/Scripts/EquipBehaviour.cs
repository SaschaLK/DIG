using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipBehaviour : MonoBehaviour {
    private Toggle toggle;

    private void Awake() {
        toggle = GetComponent<Toggle>();
    }

    public void AddTankSize(float tank) {
        if (toggle.isOn) {
            MinerGasController.instance.AddTankSize(tank);
        }
        else {
            MinerGasController.instance.AddTankSize(-tank);
        }

    }

}
