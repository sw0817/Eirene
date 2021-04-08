using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShow : MonoBehaviour
{
    public GameObject map;
    public GameObject canvas;
    public static bool isHelp = false;
    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHelp)
        {
            ShowMap();
        }
    }
    public void ShowMap()
    {
        map.SetActive(true);
        canvas.SetActive(true);
    }
}
