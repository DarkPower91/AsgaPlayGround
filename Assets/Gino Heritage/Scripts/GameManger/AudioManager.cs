using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip m_MainMenuSound = null;
    public AudioClip m_InGameSoundIntro = null;
    public AudioClip m_InGameSoundLoop = null;
    public AudioClip m_InCreditsEasterEgg = null;

    private AudioSource m_BackgroundMusicSource =  null;
    private GameState m_PreviousGameState = GameState.MainMenu;

    private bool isMuted = false;

    private float m_IntroLenght = 0.0f;

    void Start()
    {
        m_BackgroundMusicSource = GetComponent<AudioSource>();
        
        m_BackgroundMusicSource.clip = m_MainMenuSound;
        m_BackgroundMusicSource.Play();
        m_IntroLenght = m_InGameSoundIntro.length;

        FlowManager.OnGameStateChanged += OnGameStateChanged;
    }

    void Update()
    {
        if(m_PreviousGameState == GameState.InGame)
        {
            if(!m_BackgroundMusicSource.isPlaying)
            {
                m_BackgroundMusicSource.clip = m_InGameSoundLoop;
                m_BackgroundMusicSource.loop = true;
                m_BackgroundMusicSource.Play();
            }
        }
    }

    void OnDestroy() 
    {
        FlowManager.OnGameStateChanged -= OnGameStateChanged;
    }

    void OnGameStateChanged(GameState newState)
    {
        if(newState != m_PreviousGameState && newState != GameState.GameOver && newState != GameState.InCredits && newState != GameState.InDex)
        {
            switch(newState)
            {
                case GameState.MainMenu:
                {
                    m_BackgroundMusicSource.Stop();
                    m_BackgroundMusicSource.clip = m_MainMenuSound;
                    m_BackgroundMusicSource.loop = true;
                    m_BackgroundMusicSource.Play();
                    break;
                }
                case GameState.InGame:
                {
                    m_BackgroundMusicSource.Stop();
                    m_BackgroundMusicSource.clip = m_InGameSoundIntro;
                    m_BackgroundMusicSource.loop = false;
                    m_BackgroundMusicSource.Play();
                    break;
                }
                /*
                case GameState.InCredits:
                {
                    m_BackgroundMusicSource.clip = m_InCreditsEasterEgg;
                    m_BackgroundMusicSource.loop = true;
                    break;
                }
                */
            }
            m_PreviousGameState = newState;
        }
    }

    public void MuteAudio(bool wantToMute)
    {
        isMuted = wantToMute;
        AudioListener.volume = wantToMute ? 0.0f : 1.0f;
    }
    
    public bool IsMuted()
    {
        return isMuted;
    }
}
