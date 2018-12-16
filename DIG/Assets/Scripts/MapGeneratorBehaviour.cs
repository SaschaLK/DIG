using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorBehaviour : MonoBehaviour {

    public static MapGeneratorBehaviour instance;

    public GameObject mapTile;
    public int mapRowTileAmountOdd;

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
        //(Set by collider size)
        mapTileXSize = mapTile.GetComponent<BoxCollider2D>().size.x;
        mapTileYSize = mapTile.GetComponent<BoxCollider2D>().size.y;
    }

    private void GenerateTileLists() {
        //Add Lists to the masterList
        mapTileLists.Add(mapTilesRowOne);
        mapTileLists.Add(mapTilesRowTwo);
        mapTileLists.Add(mapTilesRowThree);

        //Instantiate all Tiles and add each row to one List. 
        for (int i = 0; i < 3; i++) {
            for (int k = 0; k < mapRowTileAmountOdd; k++) {
                mapTileLists[i].Add(Instantiate(mapTile,transform));

                //Set middle Tile as main collider
                if(k == mapRowTileAmountOdd / 2 + 0.5) {
                    mapTileLists[i][k].GetComponent<BoxCollider2D>().size = new Vector2(mapTileXSize * mapRowTileAmountOdd, mapTileYSize);
                }
                else {
                    mapTileLists[i][k].GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }

    private void PositionStartTiles() {
        //Position Each Tile / Row for Start of Game
        //Positioning on X and Y axes
        int tempRowKey = 0;
        foreach(List<GameObject> tileList in mapTileLists) {
            int tempTileKey = 0;
            for (float i = mapRowTileAmountOdd / 2 * -1; i < mapRowTileAmountOdd / 2 + 1; i++) {
                tileList[tempTileKey].transform.position = new Vector3(mapTileXSize * i, mapTileYSize * -tempRowKey, 0);
                tempTileKey++;
            }
            tempRowKey++;
        }
    }
}
