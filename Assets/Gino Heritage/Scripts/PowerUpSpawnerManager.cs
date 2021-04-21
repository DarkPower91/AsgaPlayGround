using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerManager : MonoBehaviour
{
    public float m_SpawnDelay = 25.0f;
    
    #region Private 
    [SerializeField]
    private List<GameObject> m_OtherDB = new List<GameObject>();
    public float minSpeed = 0.5f;
    public float maxSpeed = 8.0f;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
        IEnumerator SpawnWave()
    {
        while(true) //TODO give control to start the wave
        {
            yield return new WaitForSeconds(m_SpawnDelay);
            if(FlowManager.GetGameState() == GameState.InGame)
           {
               SpawnPowerUp(); 
           }
        }
    }

    void SpawnPowerUp() 
    {
        int powerUpIndex = Random.Range(0, m_OtherDB.Count);
        GameObject powerUp = Instantiate(m_OtherDB[powerUpIndex]) as GameObject;

        float otherBBy = powerUp.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector2 screenBounds = ScreenBounds.GetScreenBounds();
        float yPosition = Random.Range(-screenBounds.y + otherBBy/2, screenBounds.y - otherBBy/2);

        float speed = - Random.Range(minSpeed, maxSpeed);
 
        powerUp.transform.position = new Vector2(screenBounds.x * 1.5f, yPosition);

        powerUp.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);

    }
}
