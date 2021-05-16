using UnityEngine;
using Zone.Core.Audio;
using Zone.Core.Utils;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController: MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private LineRenderer[] lines;
    private Rigidbody rb;
    private bool laserOn;
    private Timer lineTimer;
    private float lineTime = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        GameManager.instance.ResetState();

        lineTimer = new Timer(lineTime);
        lineTimer.OnTimerEnd += LaserEnd;
        foreach (var line in lines)
        {
            line.enabled = false;
        }
    }

    private void Update() 
    {
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.green);
        if (laserOn)
            lineTimer.Tick(Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
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

        //Vector3 laserTarget = shootPosition + shootDirection * 10f;
        //Vector3 laserTarget = new Vector3()
        foreach (var laser in lines)
        {
            laser.enabled = true;
            //laser.SetPosition(1, laserTarget);
        }
        laserOn = true;

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

    private void LaserEnd()
    {
        foreach (var line in lines)
        {
            line.enabled = false;
        }
        laserOn = false;
        lineTimer.Reset();
    }
}
