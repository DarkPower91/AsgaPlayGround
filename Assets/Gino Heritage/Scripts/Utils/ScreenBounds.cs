using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    public static Vector2 GetScreenBounds()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
}
