using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioButton : MonoBehaviour
{
    public bool m_WantToMute = false;
    public GameObject m_OppositeButton;
    private AudioManager m_AudioManager = null;
    private bool isInit = false;

    private void Init()
    {
        m_AudioManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioManager>();
        if(m_AudioManager !=null)
        {
            if(m_AudioManager.IsMuted())
            {
                if(m_WantToMute)
                {
                    this.gameObject.SetActive(false);
                }
            }
            else
            {
                if(!m_WantToMute)
                {
                    this.gameObject.SetActive(false);
                }
            }
            isInit = true;
        }
    }
    private void Update()
    {
        if(!isInit)
        {
            Init();
        }
    }
    public void OnClickMe()
    {
        if(m_AudioManager != null)
        {
            m_AudioManager.MuteAudio(m_WantToMute);
            m_OppositeButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
