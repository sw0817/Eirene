using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveLoginInfo : MonoBehaviour
{
    public string loginNickname;
    public string myId;
    public static string tempNickname;
    public static string tempId;
    public static bool getTime;
    public GameObject saveInfo;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(saveInfo);
    }

    // Update is called once per frame
    void Update()
    {
        if (getTime)
        {
            loginNickname = tempNickname;
            myId = tempId;
            getTime = false;
            SceneManager.LoadScene("Lobby");
        }
    }

    public static void GetInfo(string userNickname, string userId)
    {
        tempId = userId;
        tempNickname = userNickname;
        getTime = true;
    }
}
