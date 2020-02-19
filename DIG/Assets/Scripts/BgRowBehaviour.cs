using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRowBehaviour : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D collision) {
        transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y - 14, 0);
    }





}
