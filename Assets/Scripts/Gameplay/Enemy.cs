using UnityEngine;
using Zone.Core.Audio;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float speedMin = 0f;
    [SerializeField] private float speedMax = 5f;
    private float speed;

    [SerializeField] private int health = 3; // TODO do we want 3 health on enemy

    private Vector3 playerPos;

    private void Start() 
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        speed = Random.Range(speedMin, speedMax);
    }

    private void Update() 
    {
        Vector3 dir = (playerPos - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.Play("explode");
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            AudioManager.instance.Play("explode");
            GameManager.instance.health--;
        }    
    }

    private void OnDestroy() 
    {
        EnemyManager.instance.planetCount--;    
    }

}
