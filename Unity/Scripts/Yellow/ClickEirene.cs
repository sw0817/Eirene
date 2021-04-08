using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEirene : MonoBehaviour
{
    public GameObject eirene;
    public GameObject reticle;
    public GameObject fadeOut;
    public GameObject finalBook;
    public GameObject eireneStar;
    public MeshCollider eireneCollider;

    GameObject initialInfo;
    int curStageNum;
    string finalStage;

    private string nextScene = "1_SelectStage";
    // Start is called before the first frame update
    void Start()
    {
        eireneCollider = eirene.GetComponent<MeshCollider>();
        initialInfo = GameObject.FindWithTag("Red");
        initialInfo.GetComponent<MapSelect>().initialCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBook()
    {
        eireneCollider.enabled = true;
        eireneStar.SetActive(true);
    }

    public void ClickFinal()
    {
        reticle.SetActive(false);
        // LoadingSceneManager.LoadScene(nextScene);
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
