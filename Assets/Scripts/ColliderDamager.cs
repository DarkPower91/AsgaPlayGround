using UnityEngine;

public class ColliderDamager : MonoBehaviour
{
    public float Damage = -10.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if(playerHealth != null)
        {
            Debug.Log("UPDATECALLED");
            playerHealth.ChangeHealth(Damage);
        }
    }
}
