using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFish_1 : MonoBehaviour
{
    public GameObject StarFishF;
    public GameObject Canvas;
    public bool opencanvars = false;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickStar() {
        if (opencanvars) 
        {
            Canvas.SetActive(false);
            opencanvars = false;
        }
        else
        {
            Canvas.SetActive(true);
            opencanvars = true;
        }
    }
}
