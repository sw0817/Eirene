using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//완성후 컬러 FFFD75
public class Complete : MonoBehaviour
{
    Renderer capsuleColor;
    public bool isClicked = false;


    //Collecting클래스에서 별갯수 가져오기
    Collecting collecting;

    //Fade클래스 조절하기
    Fade fade;

    //조명
    Light light;

    //자체발광
    Material mat;

    //다음 단계 갈 준비
    public bool next = false;

    
    //별 세기 공용
    public int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        capsuleColor = gameObject.GetComponent<Renderer>();
        //조각 개수 가져오기
        collecting = GameObject.Find("PiecesOfStar").GetComponent<Collecting>(); //공통으로 바꾸려면 여기로
        //불 조절
        light = GetComponent<Light> ();
        //자체발광 조절
        Renderer renderer = GetComponent<Renderer> ();
        mat = renderer.material;       
        float emission = Mathf.PingPong (Time.time, 1.0f);
        Color baseColor = Color.grey; 
        Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
        
        //페이드 조절하기
        fade = GameObject.Find("Fade In").GetComponent<Fade>(); //공통으로 바꾸려면 여기로
    }

    // Update is called once per frame
    void Update()
    {
        // if (isClicked == true && Input.GetMouseButtonDown(0))
        if (isClicked == true && cnt >= 3)//테스트중@@일단 1
        {
            Debug.Log("다모았는가");
            capsuleColor.material.color = Color.yellow;
            // lightGameObject.transform.position = new Vector3(0, 5, 0);
            light.enabled = true;
            // isClicked == false;
            mat.SetColor ("_EmissionColor", Color.yellow);
            next = true;
            // Debug.Log("Complete 다음으로");
            GameObject.Find("Constellation").transform.Find("DeerConstellation").gameObject.SetActive(true);
            //페이드아웃 실행해야함
            fade.stopOut = false;
            cnt=0; //Update의 if()가 계속 실행되지 않도록 해준다.
        }else{
            isClicked = false;
        }
    }

    public void ClickComplete()
    {
        isClicked = true;
    }
}
