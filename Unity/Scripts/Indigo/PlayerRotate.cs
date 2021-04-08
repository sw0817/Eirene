using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]

    private GameObject theCanvas;
    public GameObject player;
    public Vector3 initialPosition;

    public float diff = 3;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = theCanvas.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yDiff = player.transform.position.y - theCanvas.transform.position.y;
        theCanvas.transform.position = theCanvas.transform.position + new Vector3(0, yDiff, 0);
        
        Debug.Log(theCanvas.transform.position);
        Debug.Log(player.transform.position);
        Vector3 direction = (theCanvas.transform.position - player.transform.position).normalized;
        Debug.Log(direction);
        theCanvas.transform.position = player.transform.position + direction * diff;
    }

}
