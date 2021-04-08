using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionOpenMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void MotionOpen(GameObject targetCanvas, GameObject theCamera)
    {
        targetCanvas.SetActive(true);
        //targetCanvas.transform.position = theCamera.transform.position + theCamera.transform.forward;
    }
}
