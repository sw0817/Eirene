using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTop : MonoBehaviour
{
    //시점전환
    public GameObject player;
    public GameObject top_jewel;
    public Vector3 offset = new Vector3(0, 5, 0);

    //연등올리기 신호
    public bool isUpOk = false;
    //음악플레이 신호
    public bool playOk=false;
    //Complete클래스에서 진행할지 말지 가져오기
    Complete complete;

    //페이드 조절
    public FadeController fader;

    // Start is called before the first frame update
    void Start()
    {
        complete = GameObject.Find("puzzle").GetComponent<Complete>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //다 모았는지 검사
        if(complete.next == true){//다 모았으면
            // Debug.Log("올라가!!");
            //페이드아웃
            
            //시점전환
            Invoke("Top",2);
            //연등 올라가기 신호 줌
            isUpOk = true;
            //음악플레이 신호줌
            playOk = true;
        }
    }

    void Top(){
        player.transform.position = top_jewel.transform.position + offset;
    }
}
