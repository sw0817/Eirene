using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpLadder : MonoBehaviour
{
    public GameObject player;
    public GameObject leftLedder;
    public GameObject rightLedder;
    public GameObject leftGem;
    public GameObject rightGem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLeftLadder()
    {
        if (Vector3.Distance(player.transform.position, leftLedder.transform.position) < 4.8)
        {
            leftGem.SetActive(true);
            player.transform.position = leftGem.transform.position;
        }
    }

    public void ClickrightLadder()
    {
        if (Vector3.Distance(player.transform.position, rightLedder.transform.position) < 4.5)
        {
            rightGem.SetActive(true);
            player.transform.position = rightGem.transform.position;
        }
    }
}
