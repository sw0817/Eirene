using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject curObj;
    public GameObject nextObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickCurObj()
    {
        nextObj.SetActive(true);
        curObj.SetActive(false);
    }
}
