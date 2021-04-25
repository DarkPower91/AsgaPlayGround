using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesCollisions : MonoBehaviour
{
    #region public Objects

    #endregion

    #region private Objects
    private Health _player_health;
    private float _damage = 0.3f;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D tiles_collision) 
    {
        // Change player health
        _player_health.ChangeHealth(_damage);
    }
}
