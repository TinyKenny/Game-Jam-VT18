using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform groundCheck;
    public LayerMask GroundLayer;

    private Rigidbody2D rb2d;
    private float horizontalInput;
    private float movementSpeed = 1.0f;
    private float verticalInput;
    private float jumpPower = 10.0f;
    private bool grounded;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(new Vector3(horizontalInput, 0, 0) * movementSpeed * Time.deltaTime, Camera.main.transform);

        //grounded = Physics2D.OverlapPoint(groundCheck.position, GroundLayer);
        grounded = true;

        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalInput = 1.0f;
        }

        Vector3 movement = new Vector3(horizontalInput * movementSpeed, verticalInput * jumpPower, 0);

        rb2d.AddForce(movement * Time.deltaTime);

	}
}
