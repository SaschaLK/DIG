using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorBehaviour : MonoBehaviour {

    public static MapGeneratorBehaviour instance;

    public GameObject mapTile;

    private float mapTileXSize;
    private float mapTileYSize;
    private List<List<GameObject>> mapTileLists = new List<List<GameObject>>();
    private List<GameObject> mapTilesRowOne = new List<GameObject>();
    private List<GameObject> mapTilesRowTwo = new List<GameObject>();
    private List<GameObject> mapTilesRowThree = new List<GameObject>();

    private void Awake() {
        instance = this;
    }

    private void Start() {
        GetSpriteSize();
        GenerateTileLists();
        PositionStartTiles();
    }

    //Method to reposition Maptile after it left vision of Camera
    public void PositionTileRow() {
        Debug.Log("Positioning");
    }

    private void GetSpriteSize() {
        //Get Size of Map Tile Sprite for future reference
        mapTileXSize = mapTile.GetComponent<BoxCollider2D>().size.x;
        mapTileYSize = mapTile.GetComponent<BoxCollider2D>().size.y;
    }

    private void GenerateTileLists() {
        //Add Lists to the masterList
        mapTileLists.Add(mapTilesRowOne);
        mapTileLists.Add(mapTilesRowTwo);
        mapTileLists.Add(mapTilesRowThree);

        //Instantiate all 9 Tiles and add each row to one List. 
        for (int i = 0; i < 3; i++) {
            for (int k = 0; k < 3; k++) {
                mapTileLists[i].Add(Instantiate(mapTile,transform));
            }
        }
    }

    private void PositionStartTiles() {
        //Position Each Tile / Row for Start of Game
        //Positioning on X axes
        foreach(List<GameObject> tileList in mapTileLists) {
            for(int i = -1; i < 2; i++) {
                tileList[i + 1].transform.position = new Vector3(mapTileXSize * i, 0, 0);
            }
        }
        //Positioning on Y axes
        for(int i = -1; i < 2; i++) {
            for(int k = 0; k < 3; k++) {
                mapTileLists[i+1][k].transform.position = new Vector3(mapTileLists[i+1][k].transform.position.x, mapTileYSize * -i, 0);
            }
        }
    }
}
