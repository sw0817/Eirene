using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScene : MonoBehaviour
{
    public Image _Image;
    public GameObject first_canvas;

    Color blackColor = Color.black;
    Color offColor = Color.clear;
    Color startColor = Color.black;
    Color targetColor = Color.black;

    private bool isOnTransition = false;
    public static bool startFadeOut = false;
    public static bool startFadeOut2 = false;
    float fadeTime = 5f;
    float delay = 0f;
    public string nextScene;
    public static string nextName;

    void Start()
    {

    }

    void Update()
    {
        if (startFadeOut)
        {
            BlackOut();
            nextScene = nextName;
            startFadeOut = false;
        }

        if (startFadeOut2)
        {
            BlackOut2();
            startFadeOut2 = false;
        }
    }

    public void BlackOut(float a_fadeTime = 5f, float a_delay = 0f)
    {
        fadeTime = a_fadeTime;
        delay = a_delay;

        _Image.enabled = true;
        startColor = _Image.color;
        targetColor = blackColor;
        _Image.raycastTarget = true;

        if (isOnTransition)
            StopCoroutine("UpdateColorCoroutine");

        StartCoroutine("UpdateColorCoroutine");
    }

    IEnumerator UpdateColorCoroutine()
    {
        isOnTransition = true;

        if (delay != 0)
            yield return new WaitForSeconds(delay);

        float t = 0;
        while (t < 1)
        {
            _Image.color = Color.Lerp(startColor, targetColor, t);
            t += Time.deltaTime / fadeTime;
            yield return new WaitForEndOfFrame();
        }
        // 시간을 지났을 경우! 즉 트랜지션 끝남
        if (targetColor == Color.clear)
        {
            _Image.enabled = false;
            first_canvas.SetActive(false);
            // Destroy(first_canvas);
            Debug.Log("진자 끝");
        }

        else if (nextScene != "")
            LoadingSceneManager.LoadScene(nextScene);

        isOnTransition = false;
    }

    public static void GoFadeOut(string nextSceneName)
    {
        startFadeOut = true;
        nextName = nextSceneName;
    }

    public void BlackOut2(float a_fadeTime = 5f, float a_delay = 0f)
    {
        fadeTime = a_fadeTime;
        delay = a_delay;

        _Image.enabled = true;
        startColor = _Image.color;
        targetColor = blackColor;
        _Image.raycastTarget = true;

        if (isOnTransition)
            StopCoroutine("UpdateColorCoroutine2");

        StartCoroutine("UpdateColorCoroutine2");
    }

    IEnumerator UpdateColorCoroutine2()
    {
        isOnTransition = true;

        if (delay != 0)
            yield return new WaitForSeconds(delay);

        float t = 0;
        while (t < 1)
        {
            _Image.color = Color.Lerp(startColor, targetColor, t);
            t += Time.deltaTime / fadeTime;
            yield return new WaitForEndOfFrame();
        }

        isOnTransition = false;
        MapSelect.StartedFadeOut();
    }

    public static void GoFadeOut2()
    {
        startFadeOut2 = true;
    }

}
