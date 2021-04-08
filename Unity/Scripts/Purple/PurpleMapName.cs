using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleMapName : MonoBehaviour
{
    public Text _text;

    Color whiteColor = Color.white;
    Color offColor = Color.clear;
    Color startColor = Color.clear;
    Color targetColor = Color.white;

    private bool isOnTransition = false;

    float fadeTime = 5f;
    float delay = 0f;

    void Start()
    {
        BlackOut();
    }

    void Update()
    {

    }

    public void BlackOut(float a_fadeTime = 2f, float a_delay = 0f)
    {
        fadeTime = a_fadeTime;
        delay = a_delay;

        startColor = _text.color;
        targetColor = offColor;

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
            _text.color = Color.Lerp(startColor, targetColor, t);
            t += Time.deltaTime / fadeTime;
            yield return new WaitForEndOfFrame();
        }
        // 시간을 지났을 경우! 즉 트랜지션 끝남

        _text.enabled = false;

        isOnTransition = false;
    }
}
