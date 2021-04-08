using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCave : MonoBehaviour
{
    public GameObject Torch;
    public bool isClick = true;
    // Start is called before the first frame update
    void Start()
    {
        Torch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpeechCheck () {
        if (isClick) {
            Torch.SetActive(true);
            isClick = false;
        }
        else {
            Torch.SetActive(false);
            isClick = true;
        }
    }
}
