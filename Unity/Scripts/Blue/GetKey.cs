using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public GameObject Key;
    // Start is called before the first frame update
    void Start()
    {
        Key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ClickKey()
    {
        GetTreasure.isKey = true;
        Key.SetActive(false);
    }
}
