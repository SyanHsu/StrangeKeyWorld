using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ƶ�״̬
/// </summary>
public class PlayerMoveStatus
{
    public PlayerMoveStatus Instance;

    public bool rightable = false;
    public bool leftable = false;
    public bool jumpable = false;
    public bool fireable = false;

    private void Awake()
    {
        Instance = this;
    }
}