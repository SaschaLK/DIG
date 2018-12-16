using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRowBehaviour : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision) {
        MapGeneratorBehaviour.instance.PositionTileRow(transform);
        MapGeneratorBehaviour.instance.PositionOres(transform);
    }

}
