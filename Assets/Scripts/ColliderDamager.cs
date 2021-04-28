using UnityEngine;
using System.Collections;

public class ColliderDamager : MonoBehaviour
{
    #region public Objects
    public float Damage = -10.0f;
    public float downtime = 5.0f;
    #endregion

    #region private Objects
    [SerializeField]
    private float _max_damage = 50f;
    private bool canDamage = true;
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if(playerHealth != null && canDamage)
        {
            playerHealth.ChangeHealth(ComputeCollisionDamage(collision));
            canDamage = false;
            StartCoroutine(DownTimer());
        }
    }

    private float ComputeCollisionDamage(Collision2D collision)
    {
        float finalDamage = Damage;

        Rigidbody2D _player_rigid_body = collision.gameObject.GetComponent<Rigidbody2D>();
        if (_player_rigid_body)
        {
            Vector2 _player_velocity = _player_rigid_body.velocity;
            if (_player_velocity != null)
            {
                finalDamage = Mathf.Clamp(Damage * _player_velocity.magnitude, -_max_damage, Damage);
            }
        }
        return finalDamage;
    }

    private IEnumerator DownTimer()
    {
        yield return new WaitForSeconds(downtime);
        canDamage = true;
    }
}
