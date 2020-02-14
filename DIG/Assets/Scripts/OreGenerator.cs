using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreGenerator : MonoBehaviour {

    //public static OreGenerator instance;

    //private void Awake() {
    //    instance = this;
    //}


    public Transform player;

    public Vector2 xSpawnRange;
    public Vector2 ySpawnRange;

    public List<Ore> ores;

    private void OnCollisionEnter2D(Collision2D collision) {
        transform.position = new Vector3(player.transform.position.x, transform.position.y);
        SpawnOres();
        transform.position = new Vector3(transform.position.x, transform.position.y - 10);
    }

    

    private void SpawnOres() {
        foreach(Ore ore in ores) {
            for(float i = 0; i > player.transform.position.y*ore.rarity; i--) {
                Instantiate(ore.oreObject, new Vector3(transform.position.x + Random.Range(xSpawnRange.x, xSpawnRange.y), transform.position.y + Random.Range(ySpawnRange.x, ySpawnRange.y)), Quaternion.identity);
            }
        }




        //Debug.Log(Mathf.PerlinNoise(Random.Range(0f, 1f), Random.Range(0f, 1f)));
        //Debug.Log(Mathf.PerlinNoise(Random.Range(0f, 1f), Random.Range(0f, 1f)));
        //Debug.Log(Mathf.PerlinNoise(Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }


}
