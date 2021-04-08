using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherOnOff : MonoBehaviour
{
    public GameObject targetEffect;
    public bool isClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnOff()
    {
        if (isClick)
        {
            isClick = false;
            targetEffect.SetActive(false);
        }
        else
        {
            isClick = true;
            targetEffect.SetActive(true);
        }
    }
}
