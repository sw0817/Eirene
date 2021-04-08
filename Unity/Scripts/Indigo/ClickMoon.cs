using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoon : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.50f;
    public Vector3 upDirect = new Vector3(0, 1, 1);

    public GameObject boat;
    public GameObject moon;
    public GameObject light1;
    public GameObject light2;
    public GameObject fadeOut;
    public GameObject reticle;
    public float moonDistance;
    public bool onClicked = false;

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
        moonDistance = moon.transform.position.y;
        if (onClicked && moonDistance < 100)
        {
            moon.transform.position = moon.transform.position + upDirect * speed * Time.deltaTime;
            light2.transform.position = light2.transform.position + upDirect * speed * Time.deltaTime;
            light1.transform.position = light1.transform.position + upDirect * speed * Time.deltaTime;
        }
    }
    public void OnClickItem()
    {
        if (19 < moonDistance)
        {
            reticle.SetActive(false);
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
            onClicked = true;
            fadeOut.SetActive(true);
            FadeOutScene.GoFadeOut(finalStage);
        }
    }

    public void ReadInfo()
    {
        initialInfo = GameObject.FindWithTag("Red");
        curStageNum = initialInfo.GetComponent<MapSelect>().curCnt;
        finalStage = initialInfo.GetComponent<MapSelect>().mapList[1];
        //Debug.Log(finalStage);
        //Debug.Log(curStageNum);
        //initialInfo.GetComponent<MapSelect>().curCnt += 1;
        //curStageNum = initialInfo.GetComponent<MapSelect>().curCnt;
        //Debug.Log(curStageNum);
    }
}
