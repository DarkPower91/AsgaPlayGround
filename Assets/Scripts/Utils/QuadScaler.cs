using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScaler : MonoBehaviour
{
    public float customScaleWidth = 1.0f;
    public float customScaleHeight = 1.0f;
    public bool scaleWidth = false;
    public bool scaleHeight = false;

    private void Start()
    {
        double height = Camera.main.orthographicSize * 2.0;
        double width = height * Screen.width / Screen.height;

        Vector3 newScale = transform.localScale;

        if(scaleWidth)
        {
            newScale[0] = (float)width * customScaleWidth;
        }    
        if(scaleHeight)
        {
            newScale[1] = (float)height * customScaleHeight;
        }

        transform.localScale = newScale;
    }
}
