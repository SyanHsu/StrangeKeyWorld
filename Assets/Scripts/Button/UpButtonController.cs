using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButtonController : ButtonController
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        if (playerMoveStatus.jumpPressed0)
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
        playerMoveStatus.jumpable0 = true;
    }
}
