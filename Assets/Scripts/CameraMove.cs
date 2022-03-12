using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ÉãÏñ»úÒÆ¶¯
/// </summary>
public class CameraMove : MonoBehaviour
{
    private Camera mainCamera;
    private PlayerMoveStatus playerMoveStatus;
    private Transform playerTransform;

    private float height;
    private float width;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        playerMoveStatus = PlayerMoveStatus.Instance;
        playerTransform = playerMoveStatus.transform;
        height = mainCamera.orthographicSize * 2;
        width = height * mainCamera.pixelWidth / mainCamera.pixelHeight;
    }

    private void LateUpdate()
    {
        if (playerTransform.position.x < transform.position.x - width / 2)
        {
            transform.Translate(transform.right * -1f * width);
            playerMoveStatus.ClearStatus();
        }
        else if (playerTransform.position.x > transform.position.x + width / 2)
        {
            transform.Translate(transform.right * 1f * width);
            playerMoveStatus.ClearStatus();
        }
        else if (playerTransform.position.y < transform.position.y - height / 2)
        {
            transform.Translate(transform.up * -1f * height);
            playerMoveStatus.ClearStatus();
        }
        else if (playerTransform.position.y > transform.position.y + height / 2)
        {
            transform.Translate(transform.up * 1f * height);
            playerMoveStatus.ClearStatus();
        }
    }
}