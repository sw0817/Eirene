using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    private static bool gatestart = false;
    public GameObject Gate;
    public GameObject Gatetransparent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gatestart)
        {
            Gate.SetActive(true);
            Destroy(Gatetransparent);
        }
    }

    public static void GatefunctionStart()
    {
        gatestart = true;
    }
}
