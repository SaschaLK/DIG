using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGenerator : MonoBehaviour {
    public static CollectibleGenerator instance;

    public Transform player;
    public List<Collectible> collectibles;

    public Vector2 xSpawnRange;
    public Vector2 ySpawnRange;

    private void Awake() {
        instance = this;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        SpawnCollectibles();
    }

    private void SpawnCollectibles() {
        foreach(Collectible collectible in collectibles) {
            for(float i = 0; i > player.transform.position.y * collectible.rarity; i--) {
                Instantiate(collectible.collectibleObject, new Vector3(transform.position.x + Random.Range(xSpawnRange.x, xSpawnRange.y), transform.position.y + Random.Range(ySpawnRange.x, ySpawnRange.y)), Quaternion.identity);
            }
        }
    }
}
