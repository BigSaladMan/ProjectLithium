using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController: MonoBehaviour
{


    [SerializeField] private float shipAccel = 7f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float rotationSpeed = 1.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        // //capped speed
        // rb.velocity = Vector3.ClampMagnitude(rb.velocity, 25f);
        // TODO might n eed more friction && might wanna move this somewhere else
        //friction (20% of speed)
        rb.AddForce(-rb.velocity.x/2f, 0f, -rb.velocity.z/2f);
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal"); 
        float y = Input.GetAxis("Vertical");

        CounterForce();

        // no going back
        if (y < 0)
            return;

        float magnitude = rb.velocity.magnitude;

        // clamping to max speed
        // TODO make sure check if this works
        if (x != 0 && y != 0 && magnitude >= maxSpeed)
            return;

        
        float multiplier = 1f;
        if (magnitude > 20f)
            multiplier = 2f;

        rb.AddForce(transform.forward * y * shipAccel * Time.deltaTime * multiplier);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + (x * rotationSpeed), transform.rotation.eulerAngles.z);
    }

    private void CounterForce()
    {
        //quick slowdown if almost stopped
        if(rb.velocity.magnitude < 1f)
        {
            rb.AddForce(-rb.velocity.x, 0f, -rb.velocity.z);
        }
    }

    //toDo class of enemy hit to be added
    public void Shoot(Vector3 shootPosition, Vector3 shootDirection)
    {
        //hit
        if(Physics.Raycast(shootPosition, shootDirection))
        {
            
        }
       
    }
}
