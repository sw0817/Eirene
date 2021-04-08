using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersLantern : MonoBehaviour
{
    public GameObject player;
    public GameObject lantern;
    private Vector3 offset = new Vector3(0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lantern.transform.position = player.transform.position - offset + player.transform.forward + player.transform.right;
    }
}
