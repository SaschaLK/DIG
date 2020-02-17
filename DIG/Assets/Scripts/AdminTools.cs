using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminTools : MonoBehaviour {
    public void ClearOres() {
        PlayerPrefs.DeleteAll();
    }
}
