using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonController : ButtonController
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        playerMoveStatus.rightable0 = true;
        if (playerMoveStatus.rightPressed0)
        {
            PressButton();
        }
        else
        {
            UnpressButton();
        }
    }
}
