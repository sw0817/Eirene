using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasure : MonoBehaviour
{
    public GameObject Smoke;
    public GameObject Chest;
    public GameObject OpenChest;
    public GameObject Canvas;
    public GameObject Canvas2;
    public static bool isKey = false;

    // Start is called before the first frame update
    void Start()
    {
        OpenChest.SetActive(false);
        Smoke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ClickBox() {
        if (isKey) {
            Smoke.SetActive(true);
            Chest.SetActive(false);
            OpenChest.SetActive(true);
            Canvas2.SetActive(true);
        }
        else {
            Canvas.SetActive(true);
        }
    }
}
