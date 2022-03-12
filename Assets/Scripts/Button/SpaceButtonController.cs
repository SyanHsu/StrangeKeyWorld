using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceButtonController : MonoBehaviour
{
    protected PlayerMoveStatus playerMoveStatus;
    protected Animator buttonAnimator;
    protected SpriteRenderer buttonRenderer;

    protected virtual void Start()
    {
        playerMoveStatus = PlayerMoveStatus.Instance;
        buttonAnimator = GetComponent<Animator>();
        buttonRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        if (playerMoveStatus.jumpPressed2)
        {
            PressButton();
        }
        else
        {
            UnpressButton();
        }
    }

    public void PressButton()
    {
        buttonAnimator.SetBool("pressed", true);
    }

    public void UnpressButton()
    {
        buttonAnimator.SetBool("pressed", false);
    }

    private void OnBecameVisible()
    {
        playerMoveStatus.jumpable2 = true;
    }
}