using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public GameObject fairy;
    public Vector3 offset = new Vector3(0, 5, 0);
    public float rotationSpeed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fairy.transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
}
