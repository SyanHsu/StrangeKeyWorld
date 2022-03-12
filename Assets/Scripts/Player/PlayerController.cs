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
    private PlayerMoveStatus playerMoveStatus;

    public float speed = 30f;
    public float jumpForce = 1000f;

    private void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMoveStatus = PlayerMoveStatus.Instance;
    }

    private float rightMove0;
    private float rightMove1;
    private bool rightMove;
    private float leftMove0;
    private float leftMove1;
    private bool leftMove;

    private void FixedUpdate()
    {
        if (playerMoveStatus.rightable0)
        {
            rightMove0 = Input.GetAxis("Right0");
            if (rightMove0 != 0) playerMoveStatus.rightPressed0 = true;
            else playerMoveStatus.rightPressed0 = false;
        }
        if (playerMoveStatus.rightable1)
        {
            rightMove1 = Input.GetAxis("Right1");
            if (rightMove1 != 0) playerMoveStatus.rightPressed1 = true;
            else playerMoveStatus.rightPressed1 = false;
        }
        if (playerMoveStatus.leftable0)
        {
            leftMove0 = Input.GetAxis("Left0");
            if (leftMove0 != 0) playerMoveStatus.leftPressed0 = true;
            else playerMoveStatus.leftPressed0 = false;
        }
        if (playerMoveStatus.leftable1)
        {
            leftMove1 = Input.GetAxis("Left1");
            if (leftMove1 != 0) playerMoveStatus.leftPressed1 = true;
            else playerMoveStatus.leftPressed1 = false;
        }
        if (playerMoveStatus.rightPressed0 || playerMoveStatus.rightPressed1 || 
            playerMoveStatus.leftPressed0 || playerMoveStatus.leftPressed1)
        {
            if (playerMoveStatus.rightPressed0 || playerMoveStatus.rightPressed1)
            {
                RightMove(Mathf.Max(rightMove0, rightMove1));
                playerMoveStatus.towardsRight = true;
            }
            if (playerMoveStatus.leftPressed0 || playerMoveStatus.leftPressed1)
            {
                LeftMove(Mathf.Max(leftMove0, leftMove1));
                playerMoveStatus.towardsRight = false;
            }
            playerAnim.SetBool("isWalking", true);
        }
        else playerAnim.SetBool("isWalking", false);

        if (playerAnim.GetBool("isOnGround"))
        {
            if (playerMoveStatus.jumpable0)
            {
                if (Input.GetButton("Jump0")) playerMoveStatus.jumpPressed0 = true;
                else playerMoveStatus.jumpPressed0 = false;
            }
            if (playerMoveStatus.jumpable1)
            {
                if (Input.GetButton("Jump1")) playerMoveStatus.jumpPressed1 = true;
                else playerMoveStatus.jumpPressed1 = false;
            }
            if (playerMoveStatus.jumpable2)
            {
                if (Input.GetButton("Jump2")) playerMoveStatus.jumpPressed2 = true;
                else playerMoveStatus.jumpPressed2 = false;
            }
            if (playerMoveStatus.jumpPressed0 || playerMoveStatus.jumpPressed1 || playerMoveStatus.jumpPressed2)
            {
                Jump();
            }
        }
        
    }

    private void RightMove(float rightMove)
    {
        transform.Translate(Vector3.right * speed * rightMove * Time.fixedDeltaTime);
        //playerRigidbody.velocity = new Vector2(speed * rightMove * Time.fixedDeltaTime, playerRigidbody.velocity.y);
    }

    private void LeftMove(float leftMove)
    {
        transform.Translate(-1f * Vector3.right * speed * leftMove * Time.fixedDeltaTime);
        //playerRigidbody.velocity = new Vector2(-1f * speed * leftMove * Time.fixedDeltaTime, playerRigidbody.velocity.y);
    }
    
    private void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpForce);
        if (playerMoveStatus.towardsRight)
        {
            playerAnim.SetBool("isRightJumping", true);
        }
        else
        {
            playerAnim.SetBool("isLeftJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Enter " + collision.collider.name);
        playerAnim.SetBool("isRightJumping", false);
        playerAnim.SetBool("isLeftJumping", false);
        if (collision.collider.tag == "Ground")
        {
            playerAnim.SetBool("isOnGround", true);
        }
        if (collision.collider.tag == "LeftWall")
        {
            playerAnim.SetBool("isOnLeftWall", true);
        }
        if (collision.collider.tag == "RightWall")
        {
            playerAnim.SetBool("isOnRightWall", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Exit " + collision.collider.name);
        if (collision.collider.tag == "Ground")
        {
            playerAnim.SetBool("isOnGround", false);
        }
        if (collision.collider.tag == "LeftWall")
        {
            playerAnim.SetBool("isOnLeftWall", false);
        }
        if (collision.collider.tag == "RightWall")
        {
            playerAnim.SetBool("isOnRightWall", false);
        }
    }
}