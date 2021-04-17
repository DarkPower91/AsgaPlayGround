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
    private SpriteRenderer spriteRenderer;
    private Vector3 startScale;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Diocane;
        startScale = transform.localScale;
        StartCoroutine(ChangeColor());
    }

    void Update()
    {
//        if (Timer < ChangeTimer)
//        {
//            Timer = Timer + Time.deltaTime;
//        }
//        else
//        {
//            spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
//            float scaleFactor = Random.Range(0.5f, 1.5f);
//            transform.localScale = startScale * scaleFactor;
//            Timer = 0;
//        }
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

    IEnumerator ChangeColor()
    {
        while(true)
        {
            yield return new WaitForSeconds(ChangeTimer);
            spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            float scaleFactor = Random.Range(0.5f, 1.5f);
            transform.localScale = startScale * scaleFactor;
        }
    }
}