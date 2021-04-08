using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class VRLookWalk : MonoBehaviourPun
{
    public Transform vrCamera;
    public float toggleAngle = 30.0f;

    // private Touch tempTouchs;
    // private Vector3 touchedPos;
    // private bool touchOn;

    public float speed = 3.0f;
    public bool moveForward;

    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        // touchOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {   
            // if(Input.touchCount > 0) // 터치가 1개 이상이면
            // {
                
            //     moveForward = true;
            // }
            // else
            // {
            //     moveForward = false;
            // }

            // if (moveForward)
            // {
            //     Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            //     cc.SimpleMove(forward * speed);
            // }
            
            // 클릭하면 moveforward = true
            if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
            {
                moveForward = true;
            }
            else
            {
                moveForward = false;
            }

            if (moveForward)
            {
                Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

                // cc.SimpleMove(forward * speed);
            }
        }
    }
}
