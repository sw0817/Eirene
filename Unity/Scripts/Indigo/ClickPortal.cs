using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPortal : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRigid;

    [SerializeField]
    private static float speed = 3.0f;
    private static float maxSpeed = 10.0f;
    private static float minSpeed = 1.0f;

    // public GameObject portal;
    public GameObject player;
    public GameObject theCamera;
    public GameObject boat;
    public GameObject moon;
    public GameObject paddle;
    public GameObject paddleMsg;
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject rightLadder;
    public GameObject leftLadder;
    public GameObject leftParticle;
    public GameObject rightParticle;
    public GameObject secondStepInfo;
    public GameObject finalStepInfo;
    public GameObject moonInfo;

    public bool onClickedFirst = false;
    public bool onClickedSecond = false;
    public bool onClickedLeft = false;
    public bool onClickedRight = false;
    public bool onClickedFinal = false;
    public bool havePaddle = false;
    public bool boatTurn = true;
    public bool moonUp = false;
    public static bool StepPlus = false;
    public float portalDistance;
    public float moonDistance;
    public float nextAngle;
    public float moonSpeed = 1.0f;

    private Vector3 dir;
    private Vector3 offset = new Vector3(0, 0, 2);
    private Vector3 leftLadderTargetPosition;
    private Vector3 rightLadderTargetPosition;
    private Vector3 finalPosition = new Vector3(-88.04f, 9.96f, 48.9f);
    public int step = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = player.GetComponent<Rigidbody>();
        leftLadderTargetPosition = leftLadder.transform.position - offset;
        rightLadderTargetPosition = rightLadder.transform.position - offset;
    }
    public void OnClickItem()
    {
        portalDistance = Vector3.Distance(player.transform.position, boat.transform.position);
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);

        if (portalDistance < 7 && player.transform.position.z < 8 && havePaddle)
        {
            myRigid.useGravity = false;
            player.transform.position = boat.transform.position - new Vector3(0, 1, 0);
            player.transform.rotation = boat.transform.rotation;
            paddle.transform.position = boat.transform.position + new Vector3(0, 1, 0);
            paddle.transform.rotation = boat.transform.rotation;
            onClickedFirst = true;
        }

        if (havePaddle == false)
        {
            paddleMsg.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);

        if(onClickedFirst && boat.transform.position.z < 3.4f)
        {
            // Move();
            transform.position = transform.position + speed * transform.forward * Time.deltaTime;
            paddle.transform.position = paddle.transform.position + speed * transform.forward * Time.deltaTime;
            player.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
            if(minSpeed < speed)
            {
                speed -= 0.001f;
            }
        }

        if (onClickedRight && onClickedFirst)
        {
            //boat.transform.position += (rightLadder.transform.position - boat.transform.position).normalized * speed * Time.deltaTime;
            //paddle.transform.position += (rightLadder.transform.position - boat.transform.position).normalized * speed * Time.deltaTime;
            //player.transform.position += (rightLadder.transform.position - boat.transform.position).normalized * speed * Time.deltaTime;

            boat.transform.position += boat.transform.forward * speed * Time.deltaTime;
            paddle.transform.position += boat.transform.forward * speed * Time.deltaTime;
            player.transform.position += boat.transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(boat.transform.position, rightLadder.transform.position) < 6 && boatTurn)
            {
                boatTurn = false;
                boat.transform.Rotate(0, nextAngle, 0);
            }

            if (Vector3.Distance(boat.transform.position, rightLadder.transform.position) < 4.5)
            {
                onClickedFirst = false;
                rightLadder.GetComponent<MoveUpLadder>().enabled = true;
            }
        }

        if (onClickedLeft && onClickedFirst)
        {
            //boat.transform.position += (leftLadder.transform.position - boat.transform.position).normalized * speed * Time.deltaTime;
            //paddle.transform.position += (leftLadder.transform.position - boat.transform.position).normalized * speed * Time.deltaTime;
            //player.transform.position += (leftLadder.transform.position - boat.transform.position).normalized * speed * Time.deltaTime;

            boat.transform.position += boat.transform.forward * speed * Time.deltaTime;
            paddle.transform.position += boat.transform.forward * speed * Time.deltaTime;
            player.transform.position += boat.transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(boat.transform.position, leftLadder.transform.position) < 6.6 && boatTurn)
            {
                boatTurn = false;
                boat.transform.Rotate(0, nextAngle, 0);
            }

            if (Vector3.Distance(boat.transform.position, leftLadder.transform.position) < 4.8)
            {
                onClickedFirst = false;
            }
        }

        if (onClickedSecond && onClickedRight)
        {
            boat.transform.position += boat.transform.forward * speed * Time.deltaTime;
            paddle.transform.position += boat.transform.forward * speed * Time.deltaTime;
            player.transform.position += boat.transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(boat.transform.position, leftLadder.transform.position) < 5 && boatTurn)
            {
                boatTurn = false;
                boat.transform.Rotate(0, nextAngle, 0);
            }

            if (Vector3.Distance(boat.transform.position, leftLadder.transform.position) < 4.8)
            {
                onClickedSecond = false;
            }
        }

        if (onClickedSecond && onClickedLeft)
        {
            boat.transform.position += boat.transform.forward * speed * Time.deltaTime;
            paddle.transform.position += boat.transform.forward * speed * Time.deltaTime;
            player.transform.position += boat.transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(boat.transform.position, rightLadder.transform.position) < 4.8 && boatTurn)
            {
                boatTurn = false;
                boat.transform.Rotate(0, nextAngle, 0);
            }

            if (Vector3.Distance(boat.transform.position, rightLadder.transform.position) < 4.5)
            {
                onClickedSecond = false;
            }
        }

        if (onClickedRight && onClickedFirst || onClickedLeft && onClickedFirst)
        {
            if (leftArrow.transform.position.y < 25)
            {
                leftArrow.transform.position += new Vector3(0, 1, 0) * 0.5f * Time.deltaTime;
                rightArrow.transform.position += new Vector3(0, 1, 0) * 0.5f * Time.deltaTime;
                leftParticle.transform.position += new Vector3(0, 1, 0) * 0.5f * Time.deltaTime;
                rightParticle.transform.position += new Vector3(0, 1, 0) * 0.5f * Time.deltaTime;
            }
        }

        // 치트키
        if (Input.GetMouseButtonDown(1))
        {
            speed += 2.0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            speed = 1.0f;
        }

        if (StepPlus)
        {
            step += 1;
            if (step == 1)
            {
                secondStepInfo.SetActive(true);
                //secondStepInfo.transform.position = theCamera.transform.position + theCamera.transform.forward;
            }
            else if (step == 2)
            {
                moonUp = true;
                finalStepInfo.SetActive(true);
                //finalStepInfo.transform.position = theCamera.transform.position + theCamera.transform.forward;
            }
            StepPlus = false;
        }

        if (moonUp && moon.transform.position.y < 12)
        {
            moon.transform.position += new Vector3(0, 1, 0) * moonSpeed * Time.deltaTime;
        }

        if (onClickedFinal)
        {
            boat.transform.position += boat.transform.forward * speed * Time.deltaTime;
            paddle.transform.position += boat.transform.forward * speed * Time.deltaTime;
            player.transform.position += boat.transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(boat.transform.position, finalPosition) < 0.01 && boatTurn)
            {
                boatTurn = false;
                boat.transform.Rotate(0, nextAngle, 0);
            }

            if (Vector3.Distance(boat.transform.position, moon.transform.position) < 12)
            {
                moonInfo.SetActive(true);
                onClickedFinal = false;
            }
        }

        // if (onClickedFirst && 12 < moonDistance)
        // {
        //     transform.position = transform.position + speed * transform.forward * Time.deltaTime;
        //     paddle.transform.position = paddle.transform.position + speed * transform.forward * Time.deltaTime;
        //     player.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
        // }

        // Z가 14까지

        // if (moonDistance <= 12)
        // {
        //     onClickedFirst = false;
        //     player.transform.position = boat.transform.position - new Vector3(0, 1, 0);
        // }
        // myRigid.MovePosition(transform.position + speed * transform.forward);
    }

    public void GetPaddle()
    {
        havePaddle = true;
    }

    public static void Move()
    {

        float _moveDirZ = Input.GetAxisRaw("Vertical");
        bool abc = true;
        // Vector3 _moveVertical = transform.forward * _moveDirZ;
        // if (Input.GetButtonDown("Vertical"))
        if (abc)
        {
            Debug.Log(speed * Time.deltaTime);
            Debug.Log(maxSpeed * Time.deltaTime);
            Debug.Log("아래");
            if (speed < maxSpeed)
            {
                speed += 1.0f;
                Debug.Log(speed);
            }
        }
        
    }

    public void ClickRight()
    {
        if (3 < boat.transform.position.z && onClickedLeft == false && onClickedRight == false)
        {
            onClickedRight = true;
            float angle = Vector3.Angle(transform.forward, (rightLadderTargetPosition - transform.position + new Vector3(0, 3.87f, 0)));
            boat.transform.Rotate(0, angle, 0);
            // player.transform.Rotate(0, angle, 0);
            paddle.transform.Rotate(0, angle, 0);
            nextAngle = -angle;
        }
    }

    public void ClickLeft()
    {
        if (3 < boat.transform.position.z && onClickedLeft == false && onClickedRight == false)
        {
            onClickedLeft = true;
            float angle = Vector3.Angle(transform.forward, (leftLadderTargetPosition - transform.position + new Vector3(0, 3.94f, 0)));
            boat.transform.Rotate(0, -angle, 0);
            // player.transform.Rotate(0, -angle, 0);
            paddle.transform.Rotate(0, -angle, 0);
            nextAngle = angle;

        }
    }

    public void SecondLeft()
    {
        if (step == 1 && onClickedRight && onClickedFirst == false)
        {
            float angle = Vector3.Angle(transform.forward, (leftLadderTargetPosition - transform.position + new Vector3(0, 3.94f, 0)));
            boat.transform.Rotate(0, -angle, 0);
            paddle.transform.Rotate(0, -angle, 0);
            player.transform.position = boat.transform.position - new Vector3(0, 1, 0);
            player.transform.rotation = boat.transform.rotation;
            nextAngle = angle;
            onClickedSecond = true;
            boatTurn = true;
        }
    }

    public void SecondRight()
    {
        if (step == 1 && onClickedLeft && onClickedFirst == false)
        {
            float angle = Vector3.Angle(transform.forward, (rightLadderTargetPosition - transform.position + new Vector3(0, 3.87f, 0)));
            boat.transform.Rotate(0, angle, 0);
            paddle.transform.Rotate(0, angle, 0);
            player.transform.position = boat.transform.position - new Vector3(0, 1, 0);
            player.transform.rotation = boat.transform.rotation;
            nextAngle = -angle;
            onClickedSecond = true;
            boatTurn = true;
        }
    }

    public void FinalLeft()
    {
        if (step == 2 && onClickedRight)
        {
            float angle = Vector3.Angle(transform.forward, (finalPosition - transform.position));
            boat.transform.Rotate(0, angle, 0);
            paddle.transform.Rotate(0, angle, 0);
            player.transform.position = boat.transform.position - new Vector3(0, 1, 0);
            player.transform.rotation = boat.transform.rotation;
            nextAngle = -angle;
            onClickedFinal = true;
            boatTurn = true;
        }
    }

    public void FinalRight()
    {
        if (step == 2 && onClickedLeft)
        {
            float angle = Vector3.Angle(transform.forward, (finalPosition - transform.position));
            boat.transform.Rotate(0, -angle, 0);
            paddle.transform.Rotate(0, -angle, 0);
            player.transform.position = boat.transform.position - new Vector3(0, 1, 0);
            player.transform.rotation = boat.transform.rotation;
            nextAngle = angle;
            onClickedFinal = true;
            boatTurn = true;
        }
    }

    public static void IndigoStepPlus()
    {
        StepPlus = true;
    }

}
