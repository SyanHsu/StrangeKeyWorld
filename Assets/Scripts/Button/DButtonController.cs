using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DButtonController : ButtonController
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        playerMoveStatus.rightable1 = true;
        if (playerMoveStatus.rightPressed1)
        {
            PressButton();
        }
        else
        {
            UnpressButton();
        }
    }
}
