using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipSpeed: MonoBehaviour
{


    [SerializeField] private float shipAccel = 5f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //up
        if (Input.GetAxis("Vertical") > 0 )
        {
            rb.AddForce(0,0,shipAccel);
        }
        //down
        if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(0, 0, -shipAccel);
        }
        //right
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(0, shipAccel, 0);
        }
        //left
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(0, -shipAccel, 0);
        }
        //capped speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 25f);
    }
}
