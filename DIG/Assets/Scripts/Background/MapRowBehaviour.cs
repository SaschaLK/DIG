using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRowBehaviour : MonoBehaviour {

    [Range(0.01f, 1f)]
    public float tileDarkener;
    private float tileDarkenerHold;
    private List<SpriteRenderer> tileSprites = new List<SpriteRenderer>();

    private void Start() {
        tileDarkenerHold = tileDarkener;

        for(int i = 0; i < transform.childCount; i++) {
            tileSprites.Add(transform.GetChild(i).GetComponent<SpriteRenderer>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        MapGeneratorBehaviour.instance.PositionTileRow(transform);
        MapGeneratorBehaviour.instance.PositionOres(transform);
        ColorTiles();
    }

    private void ColorTiles() {
        foreach(SpriteRenderer tileSprite in tileSprites) {
            tileDarkener *= Random.Range(0.9f, 1f);
            tileSprite.color = new Color(tileSprite.color.r * tileDarkener, tileSprite.color.g * tileDarkener, tileSprite.color.b * tileDarkener);
            tileDarkener = tileDarkenerHold;
        }
    }

}
