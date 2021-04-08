using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGazePink : MonoBehaviour
{

    public GameObject Portal;
    public float totalTime = 2;
    public bool gvrStatus = false;
    
    float gvrTimer;

    public int distanceOfRay = 100;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        gvrStatus = false;
        Portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;

        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {

            if (gvrStatus && gvrTimer > totalTime)
            {
                Portal.SetActive(true);
                //CreateFlower.FlowerStart()
            }

        }

    }

    public void GVROn()
    {
        Debug.Log("Start GVRON");
        gvrStatus = true;
    }
    public void GVROff()
    {
        Debug.Log("Start GVROFF");
        gvrStatus = false;
        gvrTimer = 0;
    }

}