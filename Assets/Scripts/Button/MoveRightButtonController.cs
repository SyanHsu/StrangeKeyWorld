using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightButtonController : MonoBehaviour
{
    protected PlayerMoveStatus playerMoveStatus;
    protected Animator buttonAnimator;
    protected SpriteRenderer buttonRenderer;
    protected BoxCollider2D[] buttonCollider;
    public Transform keyTransform;
    public Transform buttonTransform;

    public float speed = 10f;
    public static bool moveable = true;

    protected float defaultY = 0.4f;
    protected float pressedY = -0.3f;

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

    public void PressButton()
    {
        buttonAnimator.SetBool("pressed", true);
        keyTransform.localPosition = new Vector3(keyTransform.localPosition.x, pressedY, keyTransform.localPosition.z);
        foreach (var item in buttonCollider)
        {
            item.enabled = false;
        }
        if (moveable) buttonTransform.Translate(Vector3.right * speed * Time.deltaTime);
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
