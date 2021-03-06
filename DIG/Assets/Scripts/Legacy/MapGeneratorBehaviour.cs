﻿using System.Collections;
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
    public List<GameObject> oreTypes = new List<GameObject>();
    public float minimumOreDepth;
    public Vector2 oreJiggleField;
    private List<List<GameObject>> oreTypeLists = new List<List<GameObject>>();
    private Dictionary<GameObject, List<List<GameObject>>> oreListsPerRows = new Dictionary<GameObject, List<List<GameObject>>>();

    //current oreRow to move next
    private enum Row { First, Second, Third };
    private Row oldestRow = Row.First;

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
        //Lists for all types of ores in game:
        foreach(GameObject oreType in oreTypes) {
            oreTypeLists.Add(new List<GameObject>());
        }

        //Adding rowOBJECTS!!!! to dictionary
        for(int i = 0; i < 3; i++) {
            oreListsPerRows.Add(mapTileParents[i], new List<List<GameObject>>());
        }

        //Adding oreLists to rowOBJECTS; Each Row has it's own oreLists and own oreObjects, assigned and sorted by dictionary.
        foreach (KeyValuePair<GameObject, List<List<GameObject>>> row in oreListsPerRows) {
            //Adding oreLists to each rowOBJECT
            foreach (GameObject oreType in oreTypes) {
                row.Value.Add(new List<GameObject>());
            }

            //Adding ores to each oreList in each row
            int tempOreTypeIndex = 0;
            foreach (List<GameObject> oreList in row.Value) {
                for (int i = 0; i < oreDensity.x * oreDensity.y; i++) {
                    oreList.Add(Instantiate(oreTypes[tempOreTypeIndex], transform));
                }
                tempOreTypeIndex++;
            }
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

    //Place one image on each row of map; Fill each true node with one ore
    private void PositionStartOres() {
        bool firstLayer = true;
        foreach (KeyValuePair<GameObject, List<List<GameObject>>> listOfOreListsInEachRow in oreListsPerRows) {
            MoveOres(listOfOreListsInEachRow.Key, listOfOreListsInEachRow.Key.transform);
            if(firstLayer) {
                //Disable below threshold for surface layer at begin of game
                foreach(List<GameObject> oreList in listOfOreListsInEachRow.Value) {
                    foreach(GameObject ore in oreList) {
                        if(ore.transform.position.y > minimumOreDepth) {
                            ore.SetActive(false);
                        }
                    }
                }
            }
            firstLayer = false;
        }
    }

    //Method to reposition Maptile after it left vision of Camera
    //Triggered by MapRow
    public void PositionTileRow(Transform rowTransform) {
        //TO-DO (BUG) PLAYER CAN EXIT MAP IF HE GOES INTO ONE DIRECTION FOR LONG ENOUGH!
        rowTransform.position = new Vector3(playerTransform.position.x, lowestPositionY * mapTileYSize, 0);
        lowestPositionY--;
    }

    //Position new ore row with random image from open selection and place ores in new row ON TRIGGER EXIT OF OLD ROW
    public void PositionOres(Transform rowTransform) {
        switch (oldestRow) {
            case Row.First:
                MoveOres(mapTileParents[0], rowTransform);
                oldestRow = Row.Second;
                break;
            case Row.Second:
                MoveOres(mapTileParents[1], rowTransform);
                oldestRow = Row.Third;
                break;
            case Row.Third:
                MoveOres(mapTileParents[2], rowTransform);
                oldestRow = Row.First;
                break;
        }
    }

    //Algorythm for positioning ores for one ROW
    private void MoveOres(GameObject row, Transform rowTransform) {
        foreach(List<GameObject> oreList in oreListsPerRows[row]) {
            Vector2 tempStartNode = new Vector2(rowTransform.position.x - rowSize.x / 2, rowTransform.position.y + rowSize.y / 2);
            int tempOreIndex = 0;
            int tempNoiseMapSelectIndex = Random.Range(0, oreMaps.Count - 1);
            for(int i = 0; i < oreDensity.x; i++) {
                for(int k = 0; k < oreDensity.y; k++) {
                    if (oreMaps[tempNoiseMapSelectIndex][i, k]) {
                        oreList[tempOreIndex].transform.position = new Vector3(tempStartNode.x + (i * oreSpacing.x) + (oreJiggleField.x * Random.Range(-1, 1)), tempStartNode.y - (k * oreSpacing.y) + (oreJiggleField.y * Random.Range(-1, 1)), -1);
                        oreList[tempOreIndex].SetActive(true);
                    }
                    tempOreIndex++;
                }
            }
        }
    }
}
