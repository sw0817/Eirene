using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCrystal : MonoBehaviour
{
    public GameObject leftCrystal;
    public GameObject leftCrystalLight;
    public GameObject leftCrystalEffect;
    public GameObject preCanvas;
    public GameObject nextCanvas;

    private MeshCollider CrystalCollider;
    public static bool isCrystalSttDone = false;
    public bool isEffect = false;
    // Start is called before the first frame update
    void Start()
    {
        CrystalCollider = leftCrystal.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCrystalSttDone)
        {
            CrystalSttDone();
            isCrystalSttDone = false;
        }
    }

    public void CrystalSttDone()
    {
        leftCrystalLight.SetActive(true);
        preCanvas.SetActive(false);
        nextCanvas.SetActive(false);
        CrystalCollider.enabled = false;
        FlowerUp.EndingFlower();
        LeftTreeGrow.LeftTreeEndingStart();
        ClickPortal.IndigoStepPlus();
    }

    public static void PreCrystalSttDone()
    {
        isCrystalSttDone = true;
    }

    public void ClickCrystal()
    {
        if (isEffect == false)
        {
            isEffect = true;
            leftCrystalEffect.SetActive(true);
        }

        else
        {
            isEffect = false;
            leftCrystalEffect.SetActive(false);
        }
    }

    public void CrystalEnable()
    {
        CrystalCollider.enabled = true;
    }

}
