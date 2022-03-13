using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    protected PlayerMoveStatus playerMoveStatus;
    protected Animator buttonAnimator;
    protected SpriteRenderer buttonRenderer;
    protected BoxCollider2D[] buttonCollider;
    public Transform keyTransform;

    protected float defaultY = 0.4f;
    protected float pressedY = -0.3f;

    protected virtual void Start()
    {
        playerMoveStatus = PlayerMoveStatus.Instance;
        buttonAnimator = GetComponent<Animator>();
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonCollider = GetComponentsInChildren<BoxCollider2D>();
    }

    public void PressButton()
    {
        buttonAnimator.SetBool("pressed", true);
        keyTransform.localPosition = new Vector3(keyTransform.localPosition.x, pressedY, keyTransform.localPosition.z);
        foreach (var item in buttonCollider)
        {
            item.enabled = false;
        }
    }

    public void UnpressButton()
    {
        buttonAnimator.SetBool("pressed", false);
        keyTransform.localPosition = new Vector3(keyTransform.localPosition.x, defaultY, keyTransform.localPosition.z);
        foreach (var item in buttonCollider)
        {
            item.enabled = true;
        }
    }
}
