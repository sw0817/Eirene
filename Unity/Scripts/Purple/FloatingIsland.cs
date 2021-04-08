using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIsland : MonoBehaviour
{
    public GameObject barrel;
    public Vector3 initialBarrelPosition;
    public bool dir = true;
    public float updownSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialBarrelPosition = barrel.transform.position;
        updownSpeed = Random.Range(3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dir && barrel.transform.position.y < initialBarrelPosition.y + 8.0)
        {
            barrel.transform.position += new Vector3(0, 2.0f, 0) * updownSpeed * Time.deltaTime;
        }

        if (dir && initialBarrelPosition.y + 8.0 <= barrel.transform.position.y)
        {
            dir = false;
        }

        if (dir == false && initialBarrelPosition.y - 8.0 < barrel.transform.position.y)
        {
            barrel.transform.position -= new Vector3(0, 2.0f, 0) * updownSpeed * Time.deltaTime;
        }

        if (dir == false && barrel.transform.position.y <= initialBarrelPosition.y - 8.0)
        {
            dir = true;
        }
    }
}
