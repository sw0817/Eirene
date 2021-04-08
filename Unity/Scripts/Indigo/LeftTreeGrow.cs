using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTreeGrow : MonoBehaviour
{
    public GameObject leftTree;
    public static bool endingStart = false;
    public float maxScale = 0.01f;
    public float scale = 0.001f;
    private float growRate = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endingStart && scale < maxScale)
        {
            this.transform.localScale = Vector3.one * scale;
            scale += growRate * Time.deltaTime;
        }
    }

    public static void LeftTreeEndingStart()
    {
        endingStart = true;
    }
}
