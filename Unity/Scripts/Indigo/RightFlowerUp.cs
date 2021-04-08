using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlowerUp : MonoBehaviour
{
    public GameObject rightFlower;
    public static bool rightEndingStart = false;
    private float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightEndingStart && rightFlower.transform.position.y < 10.5)
        {
            rightFlower.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
    }

    public static void RightEndingFlower()
    {
        rightEndingStart = true;
    }
}
