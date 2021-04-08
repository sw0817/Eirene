using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEndingSound : MonoBehaviour
{
    AudioSource audioSource;
    GoToTop complete;
    public int playCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        // 뮤트: true일 경우 소리가 나지 않음
        // audioSource.mute = false;

        // 루핑: true일 경우 반복 재생
        // audioSource.loop = false;

        // 자동 재생: true일 경우 자동 재생
        // audioSource.playOnAwake = false;

        //재생할지 알기 위해 알아야 할것
        complete = GameObject.Find("puzzle").GetComponent<GoToTop>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(complete.playOk==true && playCount == 0){//엔딩 타이밍(연등 올라가기)이 되면 피아노 음악 나오기
            Invoke("Play",2.5f);
            playCount++;
        }
    }

    void Play(){
            Debug.Log("플레이"+playCount);
            this.audioSource.Play();
            complete.playOk=false;
    }
}
