using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WButtonController : ButtonController
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        playerMoveStatus.jumpable1 = true;
        if (playerMoveStatus.jumpPressed1)
        {
            PressButton();
        }
        else
        {
            UnpressButton();
        }
    }
}
