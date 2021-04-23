using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenBounds
{
    public static Vector2 Bounds
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        }
    }
}
