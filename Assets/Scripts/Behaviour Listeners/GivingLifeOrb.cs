using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivingLifeOrb : MonoBehaviour
{
    #region private Objects
    private Health _player_health = new Health();
    #endregion

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // Change player health
        _player_health.ChangeHealth(_player_health.max_health);

        if (collision.gameObject.tag == "Player") 
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
