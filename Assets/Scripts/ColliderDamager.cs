using UnityEngine;

public class ColliderDamager : MonoBehaviour
{
    #region public Objects
    public float Damage = -10.0f;
    #endregion

    #region private Objects

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if(playerHealth != null)
        {
            //Debug.Log("UPDATECALLED");
            //playerHealth.ChangeHealth(Damage);
            playerHealth.ChangeHealth(
                ComputeCollisionDamage(collision)
            );
        }
    }

    private float ComputeCollisionDamage(Collision2D collision)
    {
        Rigidbody2D _player_rigid_body = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 _player_velocity = _player_rigid_body.velocity;
        if (_player_velocity != null)
        {
            float _damage = Damage*_player_velocity.magnitude;
            //Debug.Log("Damage! it is with velocity, ad it is " + _damage);
            return _damage; 
        } else
        {
            //Debug.Log("Damage! it is without velocity");
            return Damage;
        }
    }
}
