using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Color Diocane;
    public float ChangeTimer = 0.0f;
    public float Speed = 0.1f;
    public float JumpSpeed = 1.0f;

    private float Timer = 0.0f;
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Diocane;
//        StartCoroutine(ChangeColor());
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * Speed;
        translation *= Time.deltaTime;
        transform.position += Vector3.right * translation;
        //transform.Translate(Vector3.right * translation);

        if(Timer >= ChangeTimer)
        {
            renderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            transform.localScale.x = Random.Range(0.5, 1.5);
            Timer = 0;
        }
        else        
        {
            Timer = Timer + Time.deltaTime;
        }
    }

    void FixedUpdate() 
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpSpeed, ForceMode2D.Impulse);
        }
    }

//    IEnumerator ChangeColor()
//    {
//        while(true)
//        {
//            yield return new WaitForSeconds(ChangeTimer);
//            renderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
//        }
//    }
}