using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    public bool gvrStatus = false;
    public bool gvrparticleStatus = false;
    float gvrTimer;
    public float lightonetime = 0;


    public int distanceOfRay = 100;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        gvrStatus = false;
        gvrparticleStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;

        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {


            if (imgGaze.fillAmount == 1 && gvrStatus && _hit.transform.CompareTag("Standinglight"))
            {
                lightonetime += 1;
                Debug.Log("불빛이벤트시작이다마");
                _hit.transform.GetComponent<GazeLightEvent>().OnOffLight();

            }

            if (imgGaze.fillAmount == 1 && gvrStatus && _hit.transform.CompareTag("Deer"))
            {
                Debug.Log("노루를 째려보는중이냐");
                Deer.DeerLookat();
            }

        }


    }

    public void GVROn()
    {
        gvrStatus = true;
    }
    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        lightonetime = 0;
    }

    public void particleGVRCheck()
    {
        //Ray ray2 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Ray ray3 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.Log(_hit.transform);
        if (!_hit.transform)
        {
            Debug.Log("너무멀어용");
        }
 
        if (Physics.Raycast(ray3, out _hit, distanceOfRay))
        {
            gvrparticleStatus = !gvrparticleStatus;
            Debug.Log(gvrparticleStatus);
            ParticleEvent();
        }


    }

    public void ParticleEvent()
    {
        //Ray ray2 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //Ray ray2 = Camera.main.ViewportPointToRay(new Vector3(0.0f, 0.0f, 0f));

            if (_hit.transform.CompareTag("Mushroom"))
            {
                Debug.Log("Hellow Mushroom");
                _hit.transform.GetComponent<ParticleTrigger>().Collect();

            }
    }
}

    // public void particleGVROn()
    //{
    //    gvrparticleStatus = true;
    //}
    // public void particleGVROff()