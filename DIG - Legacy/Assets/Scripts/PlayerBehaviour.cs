using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float digSpeed;

    private Rigidbody rb;
    private float movementHorizontal;
    private Vector3 movement = Vector3.zero;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Horizontal")) {
            movementHorizontal = Input.GetAxis("Horizontal");
            movement.x = movementHorizontal;
            movement.y = -digSpeed;
            //movement = new Vector3(movementHorizontal, -digSpeed, 0.0f);
            rb.AddForce(movement);
            Debug.Log(movementHorizontal);
        }
	}

}
