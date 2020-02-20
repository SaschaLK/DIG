using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRowBehaviour : MonoBehaviour {

    public GameObject tile;
    [Range(0, 0.9f)] public float maxColorChange;

    private List<GameObject> tiles = new List<GameObject>();

    private void Awake() {
        for(int i = -100; i < 100; i++) {
            tiles.Add(Instantiate(tile, new Vector3(i, transform.position.y, 0), Quaternion.identity, transform));
        }

        ChangeTileColors();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        transform.position = new Vector3(collision.transform.position.x, transform.position.y - 29, 0);

        ChangeTileColors();
    }

    private void ChangeTileColors() {
        foreach(GameObject tile in tiles) {
            float colorChange = Random.Range(0, maxColorChange);
            tile.GetComponent<SpriteRenderer>().color = new Color(tile.GetComponent<SpriteRenderer>().color.r - colorChange, tile.GetComponent<SpriteRenderer>().color.g - colorChange, tile.GetComponent<SpriteRenderer>().color.b - colorChange);
        }
    }
}
