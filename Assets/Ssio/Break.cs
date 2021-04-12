using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Break : MonoBehaviour
{
    public GameObject BrokenScreen;
    public float RestartTimer;

    void OnJointBreak2D(Joint2D brokenJoint)
    {
        if(BrokenScreen)
        {
            BrokenScreen.active = true;
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(RestartTimer);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}

