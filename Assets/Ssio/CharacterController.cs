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
        if(Timer >= ChangeTimer)
        {
            renderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Timer = 0;
        }
        else        
        {
            Timer = Timer + Time.deltaTime;
        }
    }

    void FixedUpdate() 
    {
        float translation = Input.GetAxis("Horizontal") * Speed;
        translation *= Time.deltaTime;
        transform.position += Vector3.right * translation;

        if(Input.GetButtonDown("Jump"))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position , Vector2.down, 1.1f);
            Debug.DrawLine(transform.position, transform.position + (Vector3.down * 2f));
            foreach(RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    if(hit.collider.gameObject != gameObject)
                    {
                        GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpSpeed, ForceMode2D.Impulse);
                    }
                }   
            }
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