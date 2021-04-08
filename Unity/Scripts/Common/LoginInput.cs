using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginInput : MonoBehaviour
{
    public Text nicknameText;
    public Image loginImage;
    public string realCurNickname = "";
    public static bool isConfirmed = false;
    public static string curNickname;

    private bool canLogin = false;
    // Start is called before the first frame update
    void Start()
    {
        nicknameText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isConfirmed)
        {
            realCurNickname = curNickname;
            nicknameText.text = "닉네임이 \"" + realCurNickname + "\" (이)가 맞습니까 ?";
            isConfirmed = false;
            canLogin = true;
            loginImage.raycastTarget = true;
        }
    }

    public static void ConfirmNickname(string nickname)
    {
        curNickname = nickname;
        isConfirmed = true;
    }

    public void ClickLogin()
    {
        ConfirmLogin.StartCheck(realCurNickname);
    }
}
