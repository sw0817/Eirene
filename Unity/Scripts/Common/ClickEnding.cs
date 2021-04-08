using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEnding : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject reticle;

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
        
    }

    public void OnClickItem()
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
        reticle.SetActive(false);
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
