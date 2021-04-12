using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Color Diocane;
    public float ChangeTimer = 0;

    private float Timer = 0;
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(ChangeColor());
    }

    void Update()
    {
        if(Timer >= ChangeTimer)
        {
            renderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Timer = 0;
        }
        else
        {
            Timer = Timer + Time.deltaTime;
            //Timer += time.deltaTime;
        }
    }
}