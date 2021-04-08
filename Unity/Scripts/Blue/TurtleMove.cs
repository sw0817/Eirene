using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMove : MonoBehaviour
{
    public GameObject Turtle;
    public GameObject Canvas;
    public GameObject Canvas2;
    public bool isClickCanvas = false;
    public static bool isClick = false;
    public static bool canvasOn = false;
    public static bool canvas2On = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (isClick)
        {
            Turtle.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (isClickCanvas)
        {
            canvasOn = true;
            isClickCanvas = false;
            Canvas.SetActive(true);
        }

        if (canvas2On)
        {
            Canvas2.SetActive(true);
            canvas2On = false;
            Canvas.SetActive(false);
        }
    }


    public static void HiTurtle () {
        if (canvasOn)
        {
            isClick = true;
            canvas2On = true;
        }
    }

    public void ClickTurtle()
    {
        isClickCanvas = true;
    }
}