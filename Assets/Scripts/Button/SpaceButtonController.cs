using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceButtonController : MonoBehaviour
{
    protected PlayerMoveStatus playerMoveStatus;
    protected Animator buttonAnimator;
    protected SpriteRenderer buttonRenderer;
    protected BoxCollider2D[] buttonCollider;

    protected virtual void Start()
    {
        playerMoveStatus = PlayerMoveStatus.Instance;
        buttonAnimator = GetComponent<Animator>();
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonCollider = GetComponentsInChildren<BoxCollider2D>();
    }
    private void Update()
    {
        if (!buttonRenderer.isVisible) return;
        playerMoveStatus.jumpable2 = true;
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
        foreach (var item in buttonCollider)
        {
            item.enabled = false;
        }
    }

    public void UnpressButton()
    {
        buttonAnimator.SetBool("pressed", false);
        foreach (var item in buttonCollider)
        {
            item.enabled = true;
        }
    }
}