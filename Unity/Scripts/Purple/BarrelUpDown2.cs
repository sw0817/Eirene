using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelUpDown2 : MonoBehaviour
{
    public GameObject barrel;
    public Vector3 initialBarrelPosition;
    public bool dir = true;
    public float updownSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialBarrelPosition = barrel.transform.position;
        updownSpeed = Random.Range(2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dir && barrel.transform.position.y < initialBarrelPosition.y + 0.3)
        {
            barrel.transform.position += new Vector3(0, 0.1f, 0) * updownSpeed * Time.deltaTime;
        }

        if (dir && initialBarrelPosition.y + 0.3 <= barrel.transform.position.y)
        {
            dir = false;
        }

        if (dir == false && initialBarrelPosition.y - 0.3 < barrel.transform.position.y)
        {
            barrel.transform.position -= new Vector3(0, 0.1f, 0) * updownSpeed * Time.deltaTime;
        }

        if (dir == false && barrel.transform.position.y <= initialBarrelPosition.y - 0.3)
        {
            dir = true;
        }
    }
}
