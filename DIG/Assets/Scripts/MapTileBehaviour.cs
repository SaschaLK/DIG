using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileBehaviour : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
    }

    private void OnTriggerExit2D(Collider2D collision) {
        MapGeneratorBehaviour.instance.PositionTileRow();
    }

}
