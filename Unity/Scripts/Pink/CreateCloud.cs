using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCloud : MonoBehaviour
{
    public GameObject Rain;
    public static bool isCorrect = false;
    // Start is called before the first frame update
    void Start()
    {
        Rain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCorrect) {
            Rainy();
        }
    }
    public void Rainy () 
    {
        Rain.SetActive(true);
    }
}
