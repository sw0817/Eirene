using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;

    void Start()
    {
        collectParticle.Stop();
    }
    void Update()
    {
    }
    public void Collect()
    {
        Debug.Log("Hello Collect");
        // play the collect graphics
        if (GameObject.Find("Player").GetComponent<VRGaze>().gvrparticleStatus)
        {
            Debug.Log("Start particle playing");
            collectParticle.Play();

        } else
        {
            Debug.Log("Stop particle playing");
            collectParticle.Stop();

        }

        //play the collect sound effects
    }



}
