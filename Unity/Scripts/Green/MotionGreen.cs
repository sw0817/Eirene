using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class MotionGreen : MonoBehaviour
{
    GameObject userInfo;
    string userId;

    public GameObject targetCanvas;
    public GameObject player;
    public GameObject theCamera;
    public int state = 0;

    private float viewSpeed = 40.0f;
    // Start is called before the first frame update

    void Start()
    {
        userInfo = GameObject.FindWithTag("SaveInfo");
        userId = userInfo.GetComponent<SaveLoginInfo>().myId;
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance
            .GetReference($"user/{userId}")
            .ValueChanged += HandleValueChanged;
    }

    void Update()
    {
        if (state == 1)
        {
            player.transform.Rotate(Vector3.up * viewSpeed * Time.deltaTime);
        }

        else if (state == 2)
        {
            player.transform.Rotate(Vector3.up * -viewSpeed * Time.deltaTime);
        }
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        IDictionary message = (IDictionary)args.Snapshot.Value;
        string msg = message["status"].ToString();
        Debug.Log(msg);

        if (msg == "view_right".ToString())
        {
            state = 1;
        }

        else if (msg == "view_left".ToString())
        {
            state = 2;
        }

        else
        {
            state = 0;
        }

        if (msg == "rowing".ToString())
        {
            // 함수
            Debug.Log("모션짱");

        }

        if (msg == "hand".ToString())
        {
            
            Debug.Log("DeerfunctionStart");
            Deer.DeerStart();
        }

        if (msg == "menu".ToString())
        {
            MotionOpenMenu.MotionOpen(targetCanvas, theCamera);
        }
    }
}