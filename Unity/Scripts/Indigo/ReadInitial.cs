using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInitial : MonoBehaviour
{
    GameObject initialInfo;
    int curStageNum;
    string finalStage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadInfo()
    {
        initialInfo = GameObject.FindWithTag("Red");
        curStageNum = initialInfo.GetComponent<MapSelect>().curCnt;
        finalStage = initialInfo.GetComponent<MapSelect>().mapList[1];
        Debug.Log(finalStage);
        Debug.Log(curStageNum);
        initialInfo.GetComponent<MapSelect>().curCnt += 1;
        curStageNum = initialInfo.GetComponent<MapSelect>().curCnt;
        Debug.Log(curStageNum);
    }
}
