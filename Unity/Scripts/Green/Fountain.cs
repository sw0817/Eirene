using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    private static bool fountainfunctionstart = false;
    public GameObject fountainparticle;
    public GameObject deerlastscene;
    private static float deertime = 0;
    // Start is called before the first frame update
    void Start()
    {
        // deerlastscene.SetActive(false);
        // Destroy(deerlastscene);
    }

    // Update is called once per frame
    void Update()
    {
        if (fountainfunctionstart)
        {
            Debug.Log("라스트씬 생성됐다");
            // Debug.Log(deerlastscene.transform.position);
            deerlastscene.SetActive(true);
            fountainparticle.SetActive(true);




        }
    }

    public static void fountainstart()
    {
        Debug.Log("OH Fountain 적용중");
        fountainfunctionstart = true;
        //deertime += 1;
    }
}
