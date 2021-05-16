using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [Range(0f,1f)]
    [SerializeField] private float parallax = 0.5f;
    private float length;
    private float startPos;
    [SerializeField] private GameObject cam;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() 
    {
        float x = Input.GetAxis("Horizontal");
        cam.transform.position += new Vector3(x * 5f * Time.deltaTime, 0f, 0f);
    }

    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallax));
        float dist = (cam.transform.position.x * parallax);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) startPos += length*3;
        if (temp < startPos - length) startPos -= length*3;

        // offset += Time.deltaTime * scrollSpeed / 10f;
    }
}
