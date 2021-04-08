using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeletedMap : MonoBehaviour
{
    public GameObject ball;
    public GameObject effect;

    private bool seleted = false;
    private float speed = 2.0f;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (seleted && ball.transform.position.y < -5)
        {
            ball.transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }

        else if (seleted == false)
        {
            ball.transform.position = initialPosition;
        }
    }

    public void onClickBall()
    {
        if (seleted)
        {
            seleted = false;
            effect.SetActive(false);
        }
        else
        {
            seleted = true;
            effect.SetActive(true);
        }
    }
}
