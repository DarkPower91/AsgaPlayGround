using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    #region Private fields
    [SerializeField]
    private List<GameObject> m_EnemyDB = new List<GameObject>();
    [SerializeField]
    private float m_SpawnDelay = 10.0f;
    private float currentTime = 0.0f;
    private float startTime = 0.0f;
    private float InitTimeHorde = 5.0f;
    private float minSpawnDelay = 0.5f;
    #endregion

    #region Public fields
    public float decrementSpawnDelay = 0.005f;
    public float minSpeed = 1.5f;
    public float maxSpeed = 8.0f;
    #endregion


/* 
    public float changeTime = 1000.0f;
    public int increasingRate = 2;
    public int iteratorForSpawn = 0;
    public int maxTimeForChangeOfIncreasingIteratorForSpawn = 150; */





    void Start()
    {
        StartCoroutine(SpawnWave());   

        startTime = Time.time;

        //StartCoroutine(changeSpawnRate());
    }

    private void Update() 
    {
        currentTime  = Time.time - startTime;

        changeDelay();

    }

    private void changeDelay() 
    {
        
        if (currentTime > InitTimeHorde && m_SpawnDelay > minSpawnDelay) 
        {
            m_SpawnDelay -= Random.Range(0.0f, decrementSpawnDelay);
        }


    }

    IEnumerator SpawnWave()
    {
        while(true) //TODO give control to start the wave
        {
            yield return new WaitForSeconds(m_SpawnDelay);
            if(FlowManager.GetGameState() == GameState.InGame)
           {
               SpawnEnemy(); 
           }
        }
    }

    void SpawnEnemy()
    {
        int EnemyIndex = Random.Range(0, m_EnemyDB.Count);
        GameObject enemy = Instantiate(m_EnemyDB[EnemyIndex]) as GameObject;

        float enemyBBy = enemy.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector2 screenBounds = ScreenBounds.GetScreenBounds();
        float yPosition = Random.Range(-screenBounds.y + enemyBBy/2, screenBounds.y - enemyBBy/2);

        float speed = Random.Range(minSpeed, maxSpeed);

 
        enemy.transform.position = new Vector2(screenBounds.x * 1.5f, yPosition);
        enemy.GetComponent<BasicEnemy>().SetSpeed(speed);
    }

    // My personal functions
    /* private IEnumerator changeSpawnRate() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(changeTime); 
            
            if(FlowManager.GetGameState() == GameState.InGame)
            {

               if (iteratorForSpawn >= maxTimeForChangeOfIncreasingIteratorForSpawn) 
               {
                   increasingRate++;
                   iteratorForSpawn = 1;
                   
                   if (maxTimeForChangeOfIncreasingIteratorForSpawn>=2) {
                       maxTimeForChangeOfIncreasingIteratorForSpawn--;
                   }

               } else 
               {
                   iteratorForSpawn++;
               }

               m_SpawnDelay = (float) m_SpawnDelay / Random.Range(1.0f, ( (float) increasingRate + 1.0f));
           }
            
        }
    } */
}
