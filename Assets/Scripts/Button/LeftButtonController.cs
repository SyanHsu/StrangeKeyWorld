using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonController : ButtonController
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        if (playerMoveStatus.leftPressed0)
        {
            PressButton();
        }
        else
        {
            UnpressButton();
        }
    }

    private void OnBecameVisible()
    {
        playerMoveStatus.leftable0 = true;
    }
}
