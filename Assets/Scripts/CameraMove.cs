using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ƶ�
/// </summary>
public class CameraMove : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        float height = mainCamera.orthographicSize;
        float width = height * mainCamera.pixelWidth / mainCamera.pixelHeight;
    }
    
    
}