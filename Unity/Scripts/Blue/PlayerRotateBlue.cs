using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateBlue : MonoBehaviour
{
    [SerializeField]

    private GameObject theCanvas;
    public GameObject theCamera;
    public Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = theCanvas.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yDiff = theCamera.transform.position.y - theCanvas.transform.position.y;
        theCanvas.transform.position = theCanvas.transform.position + new Vector3(0, yDiff, 0);

        Debug.Log(theCanvas.transform.position);
        Debug.Log(theCamera.transform.position);
        Vector3 direction = (theCanvas.transform.position - theCamera.transform.position).normalized;
        Debug.Log(direction);
        theCanvas.transform.position = theCamera.transform.position + direction * 50;
    }
}
