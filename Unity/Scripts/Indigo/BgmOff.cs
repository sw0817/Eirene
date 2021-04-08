using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmOff : MonoBehaviour
{
    public GameObject camera;
    public static AudioSource bgmSource;
    public AudioClip bgmClip;
    // Start is called before the first frame update
    void Start()
    {
        bgmSource = camera.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void OffBgm()
    {
        bgmSource.enabled = false;
    }
}
