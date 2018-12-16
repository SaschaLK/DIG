using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorBehaviour : MonoBehaviour {

    public static MapGeneratorBehaviour instance;

    public GameObject mapTile;
    public GameObject rowParent;
    public int mapRowTileAmountOdd;

    private float mapTileXSize;
    private float mapTileYSize;
    private List<List<GameObject>> mapTileLists = new List<List<GameObject>>();
    private List<GameObject> mapTileParents = new List<GameObject>();
    private List<GameObject> mapTilesRowOneList = new List<GameObject>();
    private List<GameObject> mapTilesRowTwoList = new List<GameObject>();
    private List<GameObject> mapTilesRowThreeList = new List<GameObject>();
    private GameObject mapTileRowParent;
    private GameObject mapTilesRowOne;
    private GameObject mapTilesRowTwo;
    private GameObject mapTilesRowThree;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        GetSpriteSize();
        GenerateTileLists();
        PositionStartTiles();
    }

    //Method to reposition Maptile after it left vision of Camera
    //Triggered by MapTile
    public void PositionTileRow() {
        Debug.Log("Positioning");

    }

    private void GetSpriteSize() {
        //Get Size of Map Tile Sprite for future reference 
        //(Set by collider size)
        mapTileXSize = rowParent.GetComponent<BoxCollider2D>().size.x;
        mapTileYSize = rowParent.GetComponent<BoxCollider2D>().size.y;
    }

    private void GenerateTileLists() {
        //Creating and adding parent Objects for the TileRows
        for(int i = 0; i < 3; i++) {
            mapTileParents.Add(Instantiate(rowParent, transform));
            //Setting row collider size
            mapTileParents[i].GetComponent<BoxCollider2D>().size = new Vector2(mapTileXSize * mapRowTileAmountOdd, mapTileYSize);
            //Setting parent position
            mapTileParents[i].transform.position = new Vector3(0, mapTileYSize * -i, 0);
        }

        //Adding Lists to the masterList
        mapTileLists.Add(mapTilesRowOneList);
        mapTileLists.Add(mapTilesRowTwoList);
        mapTileLists.Add(mapTilesRowThreeList);

        //Instantiate all Tiles and add each row to one List. 
        for (int i = 0; i < 3; i++) {
            for (int k = 0; k < mapRowTileAmountOdd; k++) {
                mapTileLists[i].Add(Instantiate(mapTile, mapTileParents[i].transform));
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
