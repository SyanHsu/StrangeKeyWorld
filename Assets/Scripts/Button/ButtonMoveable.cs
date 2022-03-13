using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoveable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveRightButtonController.moveable = false;
    }
}
