using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¿ØÖÆÍæ¼Ò
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D playerRigidbody;

    public float speed = 1f;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PlayerMoveStatus.rightable0)
        {
            float rightMove = Input.GetAxis("Right0");
            if (rightMove != 0)
            {
                RightMove(rightMove);
                PlayerMoveStatus.rightPressed0 = true;
            }
            else PlayerMoveStatus.rightPressed0 = false;
        }
        if (PlayerMoveStatus.rightable1)
        {
            float rightMove = Input.GetAxis("Right1");
            if (rightMove != 0)
            {
                RightMove(rightMove);
                PlayerMoveStatus.rightPressed1 = true;
            }
            else PlayerMoveStatus.rightPressed1 = false;
        }
        if (PlayerMoveStatus.leftable0)
        {
            float leftMove = Input.GetAxis("Left0");
            if (leftMove != 0)
            {
                LeftMove(leftMove);
                PlayerMoveStatus.leftPressed0 = true;
            }
            else PlayerMoveStatus.leftPressed0 = false;
        }
        if (PlayerMoveStatus.leftable1)
        {
            float leftMove = Input.GetAxis("Left1");
            if (leftMove != 0)
            {
                LeftMove(leftMove);
                PlayerMoveStatus.leftPressed1 = true;
            }
            else PlayerMoveStatus.leftPressed1 = false;
        }
    }

    private void RightMove(float rightMove)
    {
        transform.Translate(transform.right * 1f * speed * rightMove * Time.deltaTime);
    }

    private void LeftMove(float leftMove)
    {
        transform.Translate(transform.right * -1f * speed * leftMove * Time.deltaTime);
    }
}