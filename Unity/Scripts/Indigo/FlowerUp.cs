using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerUp : MonoBehaviour
{
    public GameObject flower;
    public static bool isEnding = false;
    private float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnding && flower.transform.position.y < 11)
        {
            flower.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
    }

    public static void EndingFlower()
    {
        isEnding = true;
    }
}
