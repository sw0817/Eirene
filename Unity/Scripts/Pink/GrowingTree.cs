using UnityEngine;
using System.Collections;

public class GrowingTree : MonoBehaviour
{
    public float maxSize;
    float growRate;
    float scale = 0.0f;
    public float minRandomRate = 0.02f;
    public float maxRandomRate = 0.06f;
    Color[] colorVariations;
    public static bool isClap = false;
    public bool isSignClicked = false;

    void Start()
    {
        growRate = Random.Range(minRandomRate, maxRandomRate);
        // this.transform.Find("sub02").renderer.material.color = colorVariations[Random.Range(0, (colorVariations.Length))
    }

    void Update()
    {
        if (isClap) {
            TreeGrow ();
        }
    }
    public void TreeGrow () {
        if (CreateCloud.isCorrect && isSignClicked) 
        {
            if (scale < maxSize)
            {
                this.transform.localScale = Vector3.one * scale;
                scale += growRate * Time.deltaTime;
            }
        }
    }

    public void SignClick()
    {
        isSignClicked = true;
    }
}