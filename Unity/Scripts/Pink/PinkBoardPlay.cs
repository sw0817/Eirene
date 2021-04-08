using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBoardPlay : MonoBehaviour
{
    public GameObject board;
    public GameObject player;
    public GameObject theCamera;
    public GameObject reticle;
    public GameObject target;
    public float speed;

    public float targetDist;

    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, target.transform.position);
        if (targetDist < dist)
        {
            board.SetActive(false);
        }

        if (isPlaying)
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
            if (speed < 12 && 4.1 < player.transform.position.y)
            {
                speed *= 1.1f;
            }

            if (player.transform.transform.position.y < 4.1)
            {
                speed *= 0.99f;
            }

            if (speed < 0.2)
            {
                speed = 1;
                isPlaying = false;
                reticle.SetActive(true);
            }
            
        }
    }

    public void locatePosition()
    {
        board.SetActive(true);
    }

    public void StartPlaying()
    {
        board.SetActive(false);
        isPlaying = true;

        player.transform.rotation = board.transform.rotation;
        player.transform.Rotate(new Vector3(0, 180, 0));
        
        player.transform.position += player.transform.forward;
        theCamera.transform.Rotate(new Vector3(0, -180, 0));

        reticle.SetActive(false);
    }
}
