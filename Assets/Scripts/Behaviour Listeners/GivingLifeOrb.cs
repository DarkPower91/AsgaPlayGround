using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GivingLifeOrb : MonoBehaviour
{
    public float fadeOffSpeed = 1.0f;
    public Color disableColor = Color.cyan;

    #region private Objects
    private Light2D light = null;
    private Health _player_health;
    private bool givenHealth = false;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player_health = collision.gameObject.GetComponent<Health>();
        if (_player_health != null && !givenHealth)
        {
            // Change player health
            _player_health.ChangeHealth(_player_health.max_health);
            givenHealth = true;
            light = GetComponentInChildren<Light2D>();
            light.color = disableColor;
            //StartCoroutine(FadeOff());
        }
    }

    private IEnumerator FadeOff()
    {
        while (true)
        {
            if (light != null)
            {
                if (light.intensity <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    light.intensity -= Time.deltaTime * fadeOffSpeed;
                }
            }
            else
            {
                Destroy(gameObject);
            }

            yield return null;
        }
    }
}
