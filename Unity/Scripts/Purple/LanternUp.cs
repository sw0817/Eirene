using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternUp : MonoBehaviour
{
    public GameObject lantern;
    public float speed = 1.0f;
    private bool isClicked = false;//나중에 TRUE로 바꾸면 올라감~!!

    //올라가도 되나 확인
    GoToTop goToTop;

    //물위 둥실
    public Vector3 initialBarrelPosition;
    public bool dir = true;
    public float updownSpeed;

    // Start is called before the first frame update
    void Start()
    {
        goToTop = GameObject.Find("puzzle").GetComponent<GoToTop>(); 
        // speed = Random.Range(2.0f, 5.0f);
        speed = Random.Range(2.0f, 6.0f);

        //둥실 속도
        initialBarrelPosition = lantern.transform.position;
        updownSpeed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //물위 둥실
        if (dir && lantern.transform.position.y < initialBarrelPosition.y + 0.3)
        {
            lantern.transform.position += new Vector3(0, 0.1f, 0) * updownSpeed * Time.deltaTime;
        }

        if (dir && initialBarrelPosition.y + 0.3 <= lantern.transform.position.y)
        {
            dir = false;
        }

        if (dir == false && initialBarrelPosition.y - 0.3 < lantern.transform.position.y)
        {
            lantern.transform.position -= new Vector3(0, 0.1f, 0) * updownSpeed * Time.deltaTime;
        }

        if (dir == false && lantern.transform.position.y <= initialBarrelPosition.y - 0.3)
        {
            dir = true;
        }


        //승천파트
        if(goToTop.isUpOk==true){
            isClicked=true;
        }
        if (isClicked)
        {
            Invoke("Up",2);
        }
    }

    public void Up()
    {
        lantern.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
    }
    public void ClickLantern()
    {
        isClicked = true;
    }

}
