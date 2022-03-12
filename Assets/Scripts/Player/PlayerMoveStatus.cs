using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Íæ¼ÒÒÆ¶¯×´Ì¬
/// </summary>
public class PlayerMoveStatus : MonoBehaviour
{
    public static PlayerMoveStatus Instance;

    public bool towardsRight = true;

    public bool rightable0;
    public bool rightPressed0;
    public bool rightable1;
    public bool rightPressed1;
    public bool leftable0;
    public bool leftPressed0;
    public bool leftable1;
    public bool leftPressed1;
    public bool jumpable0;
    public bool jumpPressed0;
    public bool jumpable1;
    public bool jumpPressed1;
    public bool jumpable2;
    public bool jumpPressed2;
    public bool fireable;
    public bool firePressed;
    public bool downPressed;
    public bool sPressed;

    private void Awake()
    {
        Instance = this;
        ClearStatus();
    }

    public void ClearStatus()
    {
        rightable0 = false;
        rightPressed0 = false;
        rightable1 = false;
        rightPressed1 = false;
        leftable0 = false;
        leftPressed0 = false;
        leftable1 = false;
        leftPressed1 = false;
        jumpable0 = false;
        jumpPressed0 = false;
        jumpable1 = false;
        jumpPressed1 = false;
        jumpable2 = false;
        jumpPressed2 = false;
        fireable = false;
        firePressed = false;
        downPressed = false;
        sPressed = false;
    }
}