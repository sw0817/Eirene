using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePond : MonoBehaviour
{
    public GameObject VolumetricCloud;
    public bool isClick = true;
    public MeshCollider targetMeshCollider;
    // Start is called before the first frame update
    void Start()
    {
        VolumetricCloud.SetActive(false);
        targetMeshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpeechCheck () {
        if (isClick) {
            VolumetricCloud.SetActive(true);
            isClick = false;
        }
        else {
            VolumetricCloud.SetActive(false);
            isClick = true;
        }
    }

    public void ClickedSign()
    {
        targetMeshCollider.enabled = true;
    }
}
