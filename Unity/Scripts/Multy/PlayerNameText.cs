using UnityEngine;
using UnityEngine.UI;

public class PlayerNameText : MonoBehaviour
{
    private Text nameText;

    // string nickname = "상훈";
    private void Start()
    {
        nameText = GetComponent<Text>();

        // if(AuthManager.User != null)
        // {
        // nameText.text = $"Hi! {nickname}";
        nameText.text = $"Hi! {PlayerPrefs.GetString("NICKNAME")}";
        // }
        // else 
        // {
            // nameText.text = "ERROR: AuthManager.User == null";
        // }
    }
}
