using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoard : MonoBehaviour
{
    public GameObject board;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        board.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
