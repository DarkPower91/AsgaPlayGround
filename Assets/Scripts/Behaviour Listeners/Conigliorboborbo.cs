using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Conigliorboborbo : MonoBehaviour
{
    public float fadeOffSpeed = 1.0f;

    #region private Objects
    private Light2D light = null;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health playerHelth = collision.gameObject.GetComponent<Health>();
        if (playerHelth)
        {
            // Change player health
            playerHelth.ChangeHealth(playerHelth.max_health);

            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            light = GetComponent<Light2D>();
            StartCoroutine(FadeOff());
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
