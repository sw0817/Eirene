using Photon.Pun;
using UnityEngine;
public class PlayerCtrl : MonoBehaviourPun
{//photonView 프로퍼티만  추가하여 단순 확장한 클래스다
    // LobbyManager lobbyManager = new LobbyManager();

    public Camera vrCam;
    public float ySensitivity = 3.0f;
    public float xSensitivity = 3.0f;

    void Start()
    {       

        //만약 자신이 로컬 플레이어라면
        if (!photonView.IsMine)
        {        
            Debug.Log("PlayerPrefs.GetString(): " + PlayerPrefs.GetString("NICKNAME"));
            Debug.Log("--1-1-1-1-1-");
            Debug.Log(PhotonNetwork.NickName);
            vrCam.gameObject.SetActive(false);
            MonoBehaviour[] scripts =  GetComponents<MonoBehaviour>();

            for(int i = 0; i<scripts.Length; i++)
            {
                if (scripts[i] is PlayerCtrl) continue;
                else if (scripts[i] is PhotonTransformView) continue;
                else if (scripts[i] is PhotonView) continue;

                scripts[i].enabled = false;
            }
        }
    }

    void Update()
    {
        //만약 자신이 로컬 플레이어라면
        if (!photonView.IsMine)
        {
            return;
        }
        // float rotX = Input.GetAxis("Mouse Y") * ySensitivity;
        // float rotY = Input.GetAxis("Mouse X") * xSensitivity;
        // vrCam.transform.rotation *= Quaternion.Euler(-rotX, 0, 0);
        // this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
    }
}