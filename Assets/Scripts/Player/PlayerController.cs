using UnityEngine;

/// <summary>
/// ¿ØÖÆÍæ¼Ò
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D playerRigidbody;
    private PlayerMoveStatus playerMoveStatus;

    public Transform leftDownPoint;
    public Transform leftUpPoint;
    public Transform rightDownPoint;
    public Transform rightUpPoint;
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform upPoint;
    public Transform downPoint;
    public float checkRadius = 0.05f;

    public LayerMask groundLayer;
    public LayerMask leftWallLayer;
    public LayerMask rightWallLayer;

    public float speed = 10f;
    public float jumpForce = 15f;
    public float wallForce = 15f;

    public float maxJumpTime = 0.2f;
    public float maxFlyTime = 0.2f;

    public float defaultGravityScale = 5f;
    public float wallGravityScale = 1f;

    public float graceTime = 0.1f;
    private float graceTimer;
    public float jumpBufferTime = 0.1f;
    private float jumpBufferTimer;

    private float leftInput0;
    private float leftInput1;
    private float leftInput;
    private float rightInput0;
    private float rightInput1;
    private float rightInput;
    private float jumpTime;
    private float flyTime;

    [SerializeField]
    private bool leftPressed = false;
    [SerializeField]
    private bool rightPressed = false;
    //[SerializeField]
    //private bool jumpPressedDown = false;
    [SerializeField]
    private bool jumpPressedUp = false;
    [SerializeField]
    private bool jumpPressed = false;
    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private bool isFlying = false;
    [SerializeField]
    private bool towardsRight = true;

    private void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMoveStatus = PlayerMoveStatus.Instance;
    }

    private void FixedUpdate()
    {
        CheckPos();
        CheckFlying();
        Jump();
        Move();
    }

    private void CheckPos()
    {
        playerAnim.SetBool("isOnGround",
                    Physics2D.OverlapCircle(leftDownPoint.position, checkRadius, groundLayer) ||
                    Physics2D.OverlapCircle(downPoint.position, checkRadius, groundLayer) ||
                    Physics2D.OverlapCircle(rightDownPoint.position, checkRadius, groundLayer));
        playerAnim.SetBool("isOnLeftWall",
            Physics2D.OverlapCircle(rightDownPoint.position, checkRadius, leftWallLayer) ||
            Physics2D.OverlapCircle(rightPoint.position, checkRadius, leftWallLayer) ||
            Physics2D.OverlapCircle(rightUpPoint.position, checkRadius, leftWallLayer));
        playerAnim.SetBool("isOnRightWall",
            Physics2D.OverlapCircle(leftDownPoint.position, checkRadius, rightWallLayer) ||
            Physics2D.OverlapCircle(leftPoint.position, checkRadius, rightWallLayer) ||
            Physics2D.OverlapCircle(leftUpPoint.position, checkRadius, rightWallLayer));
        if (playerAnim.GetBool("isOnGround") || playerAnim.GetBool("isOnLeftWall") ||
            playerAnim.GetBool("isOnRightWall"))
        {
            playerAnim.SetBool("isRightJumping", false);
            playerAnim.SetBool("isLeftJumping", false);
            isFlying = isJumping = false;
        }
    }

    private void CheckFlying()
    {
        if (isFlying)
        {
            flyTime += Time.fixedDeltaTime;
            if (flyTime > maxFlyTime) isFlying = false;
            else if (playerAnim.GetBool("isLeftJumping"))
            {
                playerRigidbody.velocity = new Vector2(-wallForce, jumpForce);
            }
            else
            {
                playerRigidbody.velocity = new Vector2(wallForce, jumpForce);
            }
        }
    }

    private void Jump()
    {
        if (playerAnim.GetBool("isOnGround")) graceTimer = graceTime;
        else if (playerRigidbody.velocity.y > 0.01f) graceTimer = 0;
        else graceTimer -= Time.fixedDeltaTime;
        if (jumpBufferTimer > 0)
        {
            if (playerAnim.GetBool("isOnLeftWall"))
            {
                playerAnim.SetBool("isLeftJumping", true);
                playerRigidbody.velocity = new Vector2(-wallForce, jumpForce);
                isFlying = true;
                flyTime = 0f;
                jumpBufferTimer = 0;
            }
            else if (playerAnim.GetBool("isOnRightWall"))
            {
                playerAnim.SetBool("isRightJumping", true);
                playerRigidbody.velocity = new Vector2(wallForce, jumpForce);
                isFlying = true;
                flyTime = 0f;
                jumpBufferTimer = 0;
            }
            else if (graceTimer > 0)
            {
                if (towardsRight)
                {
                    playerAnim.SetBool("isRightJumping", true);
                }
                else
                {
                    playerAnim.SetBool("isLeftJumping", true);
                }
                playerRigidbody.velocity = Vector2.up * jumpForce;
                isJumping = true;
                jumpTime = 0f;
                jumpBufferTimer = 0;
            }
            else jumpBufferTimer -= Time.fixedDeltaTime;
        }
        if (jumpPressed)
        {
            if (isJumping)
            {
                jumpTime += Time.fixedDeltaTime;
                if (jumpTime > maxJumpTime)
                {
                    isJumping = false;
                }
                else playerRigidbody.velocity = Vector2.up * jumpForce;
            }
            jumpPressed = false;
        }
        if (jumpPressedUp)
        {
            isJumping = false;
            jumpPressedUp = false;
        }
    }

    private void Move()
    {
        if (leftPressed || rightPressed)
        {
            if (!isFlying)
            {
                if (!playerAnim.GetBool("isOnRightWall") && leftPressed)
                {
                    playerRigidbody.velocity = new Vector2
                        (-leftInput * speed, playerRigidbody.velocity.y);
                }
                if (!playerAnim.GetBool("isOnLeftWall") && rightPressed)
                {
                    playerRigidbody.velocity = new Vector2
                        (rightInput * speed, playerRigidbody.velocity.y);
                }
                if ((playerAnim.GetBool("isOnRightWall") && leftPressed) ||
                    (playerAnim.GetBool("isOnLeftWall") && rightPressed))
                {
                    playerRigidbody.gravityScale = wallGravityScale;
                }
                else
                {
                    playerRigidbody.gravityScale = defaultGravityScale;
                }
                if (playerAnim.GetBool("isOnGround"))
                {
                    playerAnim.SetBool("isWalking", true);
                }
                else
                {
                    playerAnim.SetBool("isWalking", false);
                }
            }
            leftPressed = rightPressed = false;
        }
        else
        {
            playerRigidbody.gravityScale = defaultGravityScale;
            playerAnim.SetBool("isWalking", false);
        }
    }

    private void Update()
    {
        GetDieInput();
        GetLeftInput();
        GetRightInput();
        GetJumpInput();
    }

    private void GetDieInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerMoveStatus.Revive();
        }
    }

    private void GetLeftInput()
    {
        leftInput = 0;
        if (playerMoveStatus.leftable0)
        {
            leftInput0 = Input.GetAxis("Left0");
            if (leftInput0 != 0)
            {
                playerMoveStatus.leftPressed0 = true;
                leftPressed = true;
                leftInput = leftInput0;
                towardsRight = false;
            }
            else playerMoveStatus.leftPressed0 = false;
        }
        if (playerMoveStatus.leftable1)
        {
            leftInput1 = Input.GetAxis("Left1");
            if (leftInput1 != 0)
            {
                playerMoveStatus.leftPressed1 = true;
                leftPressed = true;
                leftInput = Mathf.Max(leftInput, leftInput1);
                towardsRight = false;
            }
            else playerMoveStatus.leftPressed1 = false;
        }
    }

    private void GetRightInput()
    {
        rightInput = 0;
        if (playerMoveStatus.rightable0)
        {
            rightInput0 = Input.GetAxis("Right0");
            if (rightInput0 != 0)
            {
                playerMoveStatus.rightPressed0 = true;
                rightPressed = true;
                rightInput = rightInput0;
                towardsRight = true;
            }
            else playerMoveStatus.rightPressed0 = false;
        }
        if (playerMoveStatus.rightable1)
        {
            rightInput1 = Input.GetAxis("Right1");
            if (rightInput1 != 0)
            {
                playerMoveStatus.rightPressed1 = true;
                rightPressed = true;
                rightInput = Mathf.Max(rightInput, rightInput1);
                towardsRight = true;
            }
            else playerMoveStatus.rightPressed1 = false;
        }
    }

    private void GetJumpInput()
    {
        if (playerMoveStatus.jumpable0)
        {
            if (Input.GetButtonDown("Jump0"))
            {
                jumpBufferTimer = jumpBufferTime;
            }
            if (Input.GetButton("Jump0"))
            {
                jumpPressed = true;
                playerMoveStatus.jumpPressed0 = true;
            }
            else playerMoveStatus.jumpPressed0 = false;
            if (Input.GetButtonUp("Jump0")) jumpPressedUp = true;
        }
        if (playerMoveStatus.jumpable1)
        {
            if (Input.GetButtonDown("Jump1"))
            {
                jumpBufferTimer = jumpBufferTime;
            }
            if (Input.GetButton("Jump1"))
            {
                jumpPressed = true;
                playerMoveStatus.jumpPressed1 = true;
            }
            else playerMoveStatus.jumpPressed1 = false;
            if (Input.GetButtonUp("Jump1")) jumpPressedUp = true;
        }
        if (playerMoveStatus.jumpable2)
        {
            if (Input.GetButtonDown("Jump2"))
            {
                jumpBufferTimer = jumpBufferTime;
            }
            if (Input.GetButton("Jump2"))
            {
                jumpPressed = true;
                playerMoveStatus.jumpPressed2 = true;
            }
            else playerMoveStatus.jumpPressed2 = false;
            if (Input.GetButtonUp("Jump2")) jumpPressedUp = true;
        }
    }
}