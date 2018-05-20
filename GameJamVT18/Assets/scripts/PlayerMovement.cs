using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public LayerMask GroundLayer;
    public GameObject hookPrefab;

    private Rigidbody2D rb2d;
    private float horizontalInput;
    private float movementSpeed = 50.0f;
    private float jumpInput;
    private float jumpPower = 7.0f;
    private bool grounded;
    private bool notHook = true;
    private GameObject hook;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        grounded = rb2d.IsTouchingLayers(GroundLayer);

        if (grounded && Input.GetAxis("Jump") > 0.0f && rb2d.velocity.y <= 0.01f)
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, 0.0f, 0.0f);
            rb2d.AddForce(new Vector3(0.0f, jumpPower, 0.0f), ForceMode2D.Impulse);
        }

        float forceX = horizontalInput * movementSpeed * getSpeedModifierByState()/ (1.0f + Mathf.Abs(rb2d.velocity.x));
        rb2d.AddForce(new Vector3(forceX, 0.0f, 0.0f) * Time.deltaTime, ForceMode2D.Impulse);

        //Debug.Log(string.Format("X: {0} Y: {1}", Input.GetAxis("Right Stick X"), Input.GetAxis("Right Stick Y")));

        if (notHook)
        {
            if (Input.GetAxis("Fire1") > 0.0f)
            {
                notHook = false;
                if (hook == null)
                {
                    Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mouseLocation = new Vector3(mouseLocation.x, mouseLocation.y, 0.0f);
                    Vector3 direction = mouseLocation - transform.position;

                    grapple(direction);
                }
                else
                {
                    unGrapple();
                }
                
            }
            else if(Input.GetAxis("JS_Fire1") > 0.0f)
            {
                notHook = false;
                if (hook == null)
                {
                    if (!(Input.GetAxis("Right Stick X") == 0.0f && Input.GetAxis("Right Stick Y") == 0.0f))
                    {
                        Vector3 direction = new Vector3(Input.GetAxis("Right Stick X"), Input.GetAxis("Right Stick Y"), 0.0f);
                        grapple(direction);
                    }
                }
                else
                {
                    unGrapple();
                }
            }
        }

        if (hook != null)
        {
            Debug.DrawLine(transform.position, hook.transform.position, Color.red);
            renderGrappleLine();
            if (Input.GetAxis("Fire2") != 0.0f)
            {
                GetComponent<DistanceJoint2D>().distance += Time.deltaTime * Input.GetAxis("Fire2");
            }
            if (Physics2D.Raycast(transform.position, hook.transform.position - transform.position, Vector3.Distance(transform.position, hook.transform.position) * 0.99f, GroundLayer).collider != null)
            {
                unGrapple();
            }
        }

        if (Input.GetAxis("Fire1") == 0.0f && Input.GetAxis("JS_Fire1") == 0.0f && !notHook)
        {
            notHook = true;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            unGrapple();
            rb2d.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
	}

    void grapple(Vector3 direction)
    {
        notHook = false;
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, GroundLayer);
        hook = Instantiate(hookPrefab, rayHit.point, Quaternion.identity);

        GetComponent<DistanceJoint2D>().connectedAnchor = hook.transform.position;
        GetComponent<DistanceJoint2D>().enabled = true;
        renderGrappleLine();
        GetComponent<LineRenderer>().enabled = true;
    }

    void unGrapple()
    {
        GetComponent<DistanceJoint2D>().enabled = false;
        GetComponent<LineRenderer>().enabled = false;
        Destroy(hook);
    }

    void renderGrappleLine()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, hook.transform.position);
    }

    float getSpeedModifierByState()
    {
        if (!grounded)
        {
            if (hook != null)
            {
                return 0.1f;
            }
            return 0.2f;
        }
        return 1.0f;
    }

    void listJoysticks()
    {
        string[] joySticks = Input.GetJoystickNames();
        Debug.Log(joySticks.Length);
        for (int i = 0; i < joySticks.Length; i++)
        {
            Debug.Log(joySticks[i]);
        }
    }
}
