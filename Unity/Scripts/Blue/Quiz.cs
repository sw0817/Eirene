using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameObject Key;
    public GameObject Canvas;
    // 석상을 바라봤을 때 메뉴 출력
    public static bool isCorrect = false;
    public bool isClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCorrect) 
        {
            Key.SetActive(true);
            Canvas.SetActive(true);
            isCorrect = false;
        }
    }
    public static void Correct() 
    {
        isCorrect = true;
    }
    
    // 메뉴가 출력되면 stt 시작
}
