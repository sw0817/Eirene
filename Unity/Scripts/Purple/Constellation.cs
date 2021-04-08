using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    // Complete complete;
    public GameObject constell;

    //천천히 깜빡이기
    public bool dir = false;

    void Start()
    {
        // constell.SetActive(false);//테스트동안 주석..
    }

    void Update()
    {
        if (dir==true) //나타내기
        {
            show(constell);
        }
        else//사라지기
        {
            hide(constell);
        }
    }

    void show(GameObject obj)
    {
        Color currentColor = obj.GetComponent<MeshRenderer>().material.color;
        //1은 불투명
        currentColor.a += 0.003f;
        if(currentColor.a >= 1){
            dir = false;
        }
        obj.GetComponent<MeshRenderer>().material.color = currentColor;
    }

    void hide(GameObject obj)
    {
        Color currentColor = obj.GetComponent<MeshRenderer>().material.color;
        //0은 투명
        currentColor.a -= 0.003f;//크게할수록 빨리 사라짐
        if(currentColor.a <= 0.2){//완전히 사라졌다가 나타나고 싶으면 0으로
            dir = true;
        }
        obj.GetComponent<MeshRenderer>().material.color = currentColor;
    }
}
