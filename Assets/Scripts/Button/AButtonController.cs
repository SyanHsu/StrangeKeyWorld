using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AButtonController : ButtonController
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        playerMoveStatus.leftable1 = true;
        if (playerMoveStatus.leftPressed1)
        {
            PressButton();
        }
        else
        {
            UnpressButton();
        }
    }
}
