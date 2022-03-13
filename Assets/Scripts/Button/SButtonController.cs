using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SButtonController : ButtonController
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        if (Input.GetKey(KeyCode.S))
        {
            PressButton();
        }
        else
        {
            UnpressButton();
        }
    }
}
