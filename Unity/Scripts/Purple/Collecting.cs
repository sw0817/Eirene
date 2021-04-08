using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public GameObject star;
    public int collectCount = 0;
    public static bool startCollctBool = false;
    public bool isClicked = false;
    public bool look = false;

    Complete complete;
    // Start is called before the first frame update
    void Start()
    {
        complete = GameObject.Find("puzzle").GetComponent<Complete>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (startCollctBool) {
        //     startCollctBool = false;
        //     collect();
        // }
        // if (isClicked)
        // {
        //     collectCount++;
        //     Destroy(this.gameObject);
        //     isClicked=false;
        //     Debug.Log("클릭별수집!:"+collectCount);
        //     if(collectCount==1){
                
        //         Debug.Log("다모았다");
        //     }
        // }
        if (look==true && startCollctBool==true)
        {
            // collectCount++;
            complete.cnt += 1;
            Debug.Log("cnt:"+complete.cnt);
            Destroy(this.gameObject);
            startCollctBool=false;
            look=false;

        }
    }

    // public void collect(){
    //     collectCount++;
    //     Destroy(this.gameObject);
    //     Debug.Log("22"+this);
    //     if(collectCount==10){
    //         Debug.Log("다모았다");
    //     }
    // }

    public static void StartCollect(){
        startCollctBool = true;
    }
    public void ClickStar()
    {
        isClicked = true;
    }
    public void Staring()
    {
        Debug.Log("쳐다보는중..");
        look = true;
    }

    public void NotStaring()
    {
        Debug.Log("안쳐다보는중..");
        look = false;
    }
}
