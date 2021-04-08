using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCrystal : MonoBehaviour
{
    public GameObject rightCrystal;
    public GameObject rightCrystalLight;
    public GameObject rightCrystalEffect;
    public GameObject preCanvas;
    public GameObject nextCanvas;

    private MeshCollider CrystalCollider;
    public static bool isCrystalSttDone = false;
    public static bool rightSttDone = false;
    public bool isEffect = false;
    // Start is called before the first frame update
    void Start()
    {
        CrystalCollider = rightCrystal.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rightSttDone)
        {
            RightCrystalSttDone();
            rightSttDone = false;
        }
    }

    public void RightCrystalSttDone()
    {
        rightCrystalLight.SetActive(true);
        preCanvas.SetActive(false);
        nextCanvas.SetActive(false);
        CrystalCollider.enabled = false;
        RightFlowerUp.RightEndingFlower();
        RightTreeGrow.RightTreeEndingStart();
        ClickPortal.IndigoStepPlus();
    }

    public static void RightCrystalDone()
    {
        rightSttDone = true;
    }

    public void ClickCrystal()
    {
        if (isEffect == false)
        {
            isEffect = true;
            rightCrystalEffect.SetActive(true);
        }

        else
        {
            isEffect = false;
            rightCrystalEffect.SetActive(false);
        }
    }

    public void CrystalEnable()
    {
        CrystalCollider.enabled = true;
    }
}
