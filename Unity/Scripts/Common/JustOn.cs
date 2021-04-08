using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustOn : MonoBehaviour
{
    public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void targetOn()
    {
        targetObject.SetActive(true);
    }
}
