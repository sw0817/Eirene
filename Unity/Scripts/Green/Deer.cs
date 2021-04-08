using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    private static bool deerfunctionstart = false;
    private static bool deerfunctionlookat = false;
    public GameObject deerMessage;
    public GameObject direction;
    public GameObject mot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deerfunctionstart && deerfunctionlookat)
        {
            Debug.Log("노루야 일좀해라~~~~~");
            mot.SetActive(false);
            direction.SetActive(false);
            deerMessage.SetActive(true);
            deerfunctionstart = false;
        }
    }

    public static void DeerStart()
    {
        if (deerfunctionlookat)
        {
            deerfunctionstart = true;
        }
        
    }
    public static void DeerLookat()
    {
        deerfunctionlookat = true;
    }
}
