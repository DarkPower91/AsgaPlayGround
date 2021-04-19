using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    public bool isDuck = false; 
    public float extraDistance = 0.0f;
    public bool clearScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {

        if (other.gameObject.tag == "Player") 
        {
            if (isDuck) 
            {
                GameObject[] penemies =  GameObject.FindGameObjectsWithTag("Penemy");
                
                for (int i=0; i<penemies.Length; i++)
                {
                    Destroy(penemies[i]);
                }
            }
            else 
            {
                ComputePercurredDistance playerDistance = other.gameObject.GetComponent<ComputePercurredDistance>();
                playerDistance.addAmount(extraDistance);
            }

            Destroy(gameObject);
        }
        
    }
}
