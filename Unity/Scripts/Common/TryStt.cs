using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TryStt : MonoBehaviour
{
    public string targetWord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrySttInteraction()
    {
        GoogleVoiceSpeech.GoStt(targetWord);
    }

    public static void Interact(string targetWord)
    {
        if (targetWord == "꺼 줘")
        {
            BgmOff.OffBgm();
        }

        else if (targetWord == "일상")
        {
            LeftCrystal.PreCrystalSttDone();
        }

        else if (targetWord == "자유")
        {
            RightCrystal.RightCrystalDone();
        }

        else if (targetWord == "해왕성")
        {
            Quiz.Correct();
        }

        else if (targetWord == "힐링")
        {
            Fountain.fountainstart();
        }

        else if (targetWord == "열려라 참깨")
        {
            GateOpen.GatefunctionStart();
        }

        else if (targetWord == "사랑")
        {
            CreateCloud.isCorrect = true;
        }
        else if (targetWord == "도움")
        {
            MapShow.isHelp = true;
        }
    }
}
