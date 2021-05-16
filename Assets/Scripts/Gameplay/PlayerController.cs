using UnityEngine;
using Zone.Core.Audio;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController: MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2.0f;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        GameManager.instance.ResetState();
    }

    private void Update() 
    {
        if (Input.GetKey(KeyCode.Space))
            Shoot(transform.position, transform.forward);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal"); 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + (x * rotationSpeed), transform.rotation.eulerAngles.z);
    }

    public void Shoot(Vector3 shootPosition, Vector3 shootDirection)
    {
        AudioManager.instance.Play("shoot");
        //hit
        if (Physics.Raycast(shootPosition, shootDirection, out RaycastHit hit))
        {
            var target = hit.collider.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage();
            }
        }

    }
}
