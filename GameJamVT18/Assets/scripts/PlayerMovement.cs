using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public LayerMask GroundLayer;
    public Sprite hooksprite;

    private Rigidbody2D rb2d;
    private float horizontalInput;
    private float movementSpeed = 50.0f;
    private float jumpInput;
    private float jumpPower = 7.0f;
    private bool grounded;
    
    private GameObject hook;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        grounded = rb2d.IsTouchingLayers(GroundLayer);
        //grounded = true;


        if (grounded && Input.GetAxis("Jump") > 0.0f && rb2d.velocity.y <= 0.01f)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, 0.0f, 0.0f);
            rb2d.AddForce(new Vector3(0.0f, jumpPower, 0.0f), ForceMode2D.Impulse);
        }

        rb2d.AddForce(new Vector3(horizontalInput * movementSpeed * (grounded ? 1.0f:0.3f) / (1.0f + Mathf.Abs(rb2d.velocity.x)), 0.0f, 0.0f) * Time.deltaTime, ForceMode2D.Impulse);

        if (Input.GetMouseButtonDown(0))
        {
            if (hook == null)
            {
                Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseLocation = new Vector3(mouseLocation.x, mouseLocation.y, 0.0f);
                RaycastHit2D rayHit = Physics2D.Raycast(transform.position, mouseLocation - transform.position, Mathf.Infinity, GroundLayer);
                hook = new GameObject();
                hook.transform.position = rayHit.point;
                hook.AddComponent<SpriteRenderer>();
                hook.GetComponent<SpriteRenderer>().sprite = hooksprite;
            }
            else
            {
                Destroy(hook);
            }
        }
	}
}
