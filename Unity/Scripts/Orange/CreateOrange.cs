using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateOrange : MonoBehaviour
{
    [SerializeField]
    private GameObject orange;
    private static bool functionStart = false;
    private static bool OrangeVRfunctionStart = false;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (functionStart && OrangeVRfunctionStart)
        {
            Debug.Log("Start make orange");
            MakeOrange();
            functionStart = false;
        }
    }

    public void MakeOrange()
    {
        Debug.Log("Start MakeOrange");
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        Instantiate(orange, new Vector3(38.77f, 5.6f, -44.42f), rotation);
        OrangeVRfunctionStart = false;
    }

    public static void MakeOrangeStart()
    {
        functionStart = true;
    }

    public static void MakeOrangePlantStart()
    {
        OrangeVRfunctionStart = true;
    }

}
