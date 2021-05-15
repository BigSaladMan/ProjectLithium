using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipSpeed: MonoBehaviour
{


    [SerializeField] private float shipAccel = 7f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //quick slowdown if almost stopped
        if(rb.velocity.magnitude < 1f)
        {
            rb.AddForce(-rb.velocity.x, 0f, -rb.velocity.z);
        }
        Move();
        //capped speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 25f);
        //friction (20% of speed)
        rb.AddForce(-rb.velocity.x/5f, 0f, -rb.velocity.z/5f);
    }

    void Move()
    {
        //up
        if (Input.GetAxis("Vertical") > 0f)
        {
            if (rb.velocity.magnitude > 20f)
            {
                rb.AddForce(0f, 0f, 2 * shipAccel);
            }
            rb.AddForce(0f, 0f, shipAccel);
        }
        //down
        if (Input.GetAxis("Vertical") < 0f)
        {
            if (rb.velocity.magnitude > 20f)
            {
                rb.AddForce(0f, 0f, -2 * shipAccel);
            }
            rb.AddForce(0f, 0f, -shipAccel);
        }
        //right
        if (Input.GetAxis("Horizontal") > 0f)
        {
            if (rb.velocity.magnitude > 20f)
            {
                rb.AddForce(2 * shipAccel, 0f, 0f);
            }
            rb.AddForce(shipAccel, 0f, 0f);
        }
        //left
        if (Input.GetAxis("Horizontal") < 0f)
        {
            if (rb.velocity.magnitude > 20f)
            {
                rb.AddForce(-2 * shipAccel, 0f, 0f);
            }
            rb.AddForce(-shipAccel, 0f, 0f);
        }
    }
}
