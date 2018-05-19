using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //public Transform groundCheck;
    public LayerMask GroundLayer;

    private Rigidbody2D rb2d;
    private float horizontalInput;
    private float movementSpeed = 50.0f;
    private float jumpInput;
    private float jumpPower = 7.0f;
    private bool grounded;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(new Vector3(horizontalInput, 0, 0) * movementSpeed * Time.deltaTime, Camera.main.transform);

        grounded = rb2d.IsTouchingLayers(GroundLayer);
        //grounded = true;


        if (grounded && Input.GetAxis("Jump") > 0.0f && rb2d.velocity.y <= 0.0f)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, 0.0f, 0.0f);
            rb2d.AddForce(new Vector3(0.0f, jumpPower, 0.0f), ForceMode2D.Impulse);
        }

        rb2d.AddForce(new Vector3(horizontalInput * movementSpeed * (grounded ? 1.0f:0.3f) / (1.0f + Mathf.Abs(rb2d.velocity.x)), 0.0f, 0.0f) * Time.deltaTime, ForceMode2D.Impulse);

        
	}
}
