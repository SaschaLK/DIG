using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreGenerator : MonoBehaviour {

    public static OreGenerator instance;

    public Transform player;

    public Vector2 xSpawnRange;
    public Vector2 ySpawnRange;

    public List<Ore> ores;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        for(int i = 0; i < 20; i++) {
            Instantiate(ores[0].oreObject, new Vector3(transform.position.x + Random.Range(xSpawnRange.x, xSpawnRange.y), Random.Range(-1f, -10f)), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        transform.position = new Vector3(player.transform.position.x, transform.position.y);
        SpawnOres();
        transform.position = new Vector3(transform.position.x, transform.position.y - 10);
    }

    private void SpawnOres() {
        foreach(Ore ore in ores) {
            if(player.transform.position.y < ore.minDepth && player.transform.position.y > ore.maxDepth) {
                for(float i = 0; i > player.transform.position.y * ore.rarity; i--) {
                    Instantiate(ore.oreObject, new Vector3(transform.position.x + Random.Range(xSpawnRange.x, xSpawnRange.y), transform.position.y + Random.Range(ySpawnRange.x, ySpawnRange.y)), Quaternion.identity);
                }
            }
        }
    }
}
