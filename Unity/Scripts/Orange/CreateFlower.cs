using UnityEngine;
using System.Collections;

public class CreateFlower : MonoBehaviour
{
    float maxSize = 2.0f;
    float growRate;
    float scale = 0.0f;
    float minRandomRate = 0.5f;
    float maxRandomRate = 0.7f;
    public static bool CreateFlowerStatus = false;

    void Start()
    {
        growRate = Random.Range(minRandomRate, maxRandomRate);
        this.transform.localScale = Vector3.one * 0;
        // this.transform.Find("sub02").renderer.material.color = colorVariations[Random.Range(0, (colorVariations.Length))
    }

    void Update()
    {
        if (CreateFlowerStatus)
        {
                if (scale < maxSize)
                {
                    this.transform.localScale = Vector3.one * scale;
                    scale += growRate * Time.deltaTime;
                } 
        }
    }

    public static void FlowerStart()
    {
        CreateFlowerStatus = true;
    }
   
}