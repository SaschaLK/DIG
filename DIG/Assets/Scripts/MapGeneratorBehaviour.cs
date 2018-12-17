using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorBehaviour : MonoBehaviour {

    public static MapGeneratorBehaviour instance;

    public Transform playerTransform;

    //For generating background map
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
    private int lowestPositionY = 0;

    //For generating item noise images / maps
    public Vector2Int oreDensity;
    public int oreMapAmount;
    [Range(0,1)]
    public float spawnChance;
    private List<bool[,]> oreMaps = new List<bool[,]>();
    private Vector2 rowSize;
    private Vector2 oreSpacing;

    //Generating ore Type Lists and amount of ores;
    public int oreCacheAmount;
    public List<GameObject> oreTypes = new List<GameObject>();
    private List<List<GameObject>> oreLists = new List<List<GameObject>>();

    private void Awake() {
        instance = this;
    }

    private void Start() {
        //Generate Background Tiles, Parents and Lists of Background Tiles. Position them.
        GetSpriteSize();
        GenerateTileLists();
        PositionStartTiles();

        //Generate Ore Gameobjects and add to Lists / Noise Images
        GenerateOreLists();
        GenerateNoiseImagesForOreMaps();

        //Position Ores for Start of Game via OreNoiseImages
        PositionStartOres();
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

            lowestPositionY--;
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

    private void GenerateOreLists() {
        foreach(GameObject oreType in oreTypes) {
            oreLists.Add(new List<GameObject>());
        }
        int tempOreTypeIndex = 0;
        foreach(List<GameObject> oreList in oreLists) {
            for (int i = 0; i < oreCacheAmount; i++) {
                oreList.Add(Instantiate(oreTypes[tempOreTypeIndex], transform));
            }
            tempOreTypeIndex++;
        }
    }

    //Foreach LoadScene and PlayGame multiple image maps are generated via noise images
    private void GenerateNoiseImagesForOreMaps() {
        //Getting RowSize
        rowSize = new Vector2(mapTileParents[0].GetComponent<BoxCollider2D>().size.x, mapTileParents[0].GetComponent<BoxCollider2D>().size.y);
        oreSpacing = new Vector2(rowSize.x / oreDensity.x, rowSize.y / oreDensity.y);

        //Creating noise images for ore maps / creating ore maps
        for(int a = 0; a < oreMapAmount; a++) {
            bool[,] oreMap = new bool[oreDensity.x, oreDensity.y];
            for(int i = 0; i < oreDensity.x; i++) {
                for(int k = 0; k < oreDensity.y; k++) {
                    if(Random.Range(0f, 1f) < spawnChance) {
                        oreMap[i, k] = true;
                    }
                }
            }
            oreMaps.Add(oreMap);
        }
    }

    //TO DO, EACH ROW OF MAP HAS TO HAVE IT'S OWN ORES AND ORE NOISE MAP
    //Place one image on each row of map; Fill each true node with one ore
    private void PositionStartOres() {
        int tempOreIndex = 0;
        foreach(GameObject mapRow in mapTileParents) {
            Vector2 startNode = new Vector2(-rowSize.x / 2, mapRow.transform.position.y + (rowSize.y / 2));
            for(int i = 0; i < oreDensity.x; i++) {
                for(int k = 0; k < oreDensity.y; k++) {
                    oreLists[0][tempOreIndex].transform.position = new Vector3(startNode.x + (k * oreSpacing.x), startNode.y - (i * oreSpacing.y), oreLists[0][tempOreIndex].transform.position.z);
                    tempOreIndex++;
                }
            }
        }
    }

    //Method to reposition Maptile after it left vision of Camera
    //Triggered by MapRow
    public void PositionTileRow(Transform rowTransform) {
        //TO-DO PLAYER CAN EXIT MAP IF HE GOES INTO ONE DIRECTION FOR LONG ENOUGH!
        rowTransform.position = new Vector3(playerTransform.position.x, lowestPositionY * mapTileYSize, 0);
        lowestPositionY--;
    }

    //Position new ore row with random image from open selection and place ores in new row on trigger exit of old row
    public void PositionOres(Transform rowTransform) {
        Debug.Log("position");
    }
}
