using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnding : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject lantern;
    public GameObject lantern2;
    public GameObject lantern3;
    public bool isStart = false;

    GameObject initialInfo;
    int curStageNum;
    string finalStage;
    // Start is called before the first frame update
    void Start()
    {
        initialInfo = GameObject.FindWithTag("Red");
        initialInfo.GetComponent<MapSelect>().initialCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false)
        {
            if (200 < lantern.transform.position.y || 200 < lantern2.transform.position.y || 200 < lantern3.transform.position.y)
            {
                isStart = true;
                StartEnding();
            }
        }
    }

    public void StartEnding()
    {
        ReadInfo();
        if (curStageNum == 1)
        {
            initialInfo.GetComponent<MapSelect>().curCnt += 1;
        }
        else if (curStageNum == 2)
        {
            finalStage = "EndingScene";
            Destroy(GameObject.FindWithTag("Red"));
        }

        fadeOut.SetActive(true);
        FadeOutScene.GoFadeOut(finalStage);
    }

    public void ReadInfo()
    {
        initialInfo = GameObject.FindWithTag("Red");
        curStageNum = initialInfo.GetComponent<MapSelect>().curCnt;
        finalStage = initialInfo.GetComponent<MapSelect>().mapList[1];
    }
}
