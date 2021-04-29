using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class RabbitBhv : MonoBehaviour
{
    public GameObject EndCanvas;
    public float restartTime = 5.0f;
    public float fadeOffSpeed = 3.0f;
    private Light2D light = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(EndCanvas != null)
            EndCanvas.SetActive(true);

        light = GetComponentInChildren<Light2D>();
        FlowManager.SetFlowState(GameState.GameOver);

        StartCoroutine(FadeOff());
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(restartTime + fadeOffSpeed);
        SceneManager.LoadScene(0);
    }

    private IEnumerator FadeOff()
    {
        while (true)
        {
            if (light != null)
            {
                if (light.intensity <= 0)
                {
                    break;
                }
                else
                {
                    light.intensity += Time.deltaTime ;
                }
            }
            else
            {
                break;
            }

            yield return null;
        }
    }
}
