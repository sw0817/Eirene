using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;


public class ConfirmLogin : MonoBehaviour
{
    public GameObject loginBtn;
    public string curNickname;
    public string realNickname;
    public string myId;

    public static string preNickname;
    public static bool isChecked = false;
    // Start is called before the first frame update
    void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update()
    {
        if (isChecked)
        {
            curNickname = preNickname;
            isChecked = false;
            CheckNickname();
        }
    }

    public void CheckNickname()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("user")
        .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...

                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary message = (IDictionary)data.Value;
                    Debug.Log(data.Key);
                    Debug.Log(message["nickname"]);
                    Debug.Log(message["login"]);
                    if (message["nickname"].ToString() == curNickname)
                    {
                        realNickname = curNickname;
                        myId = data.Key;

                        Debug.Log(myId);
                        Debug.Log(realNickname);
                        // 함수써야함 다음씬/
                        SaveLoginInfo.GetInfo(realNickname, myId);
                        break;
                    }
                }
            }
        });
    }

    public static void StartCheck(string nickname)
    {
        isChecked = true;
        preNickname = nickname;
    }
}