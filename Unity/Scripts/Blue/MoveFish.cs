using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{
    float timeCounter = 0;
    float speed;
    float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(40, 80);
        rotationSpeed = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        rotationSpeed = Random.Range(10, 20);
    }
}
