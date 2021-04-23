using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersLoader : MonoBehaviour
{
    #region Serialized fields
    [SerializeField] private GameObject m_SaveDataRepository = null;
    [SerializeField] private GameObject m_FlowManager = null;
    [SerializeField] private GameObject m_MusicManager = null;
    [SerializeField] private GameObject m_LocalizationData = null;
    #endregion

    private void Start()
    {
        if (!GameObject.FindGameObjectWithTag("SaveData"))
        {
            GameObject saveData = Instantiate(m_SaveDataRepository, transform.position, Quaternion.identity);
            DontDestroyOnLoad(saveData);
        }

        if (!GameObject.FindGameObjectWithTag("MusicManager"))
        {
            GameObject musicManager = Instantiate(m_MusicManager, transform.position, Quaternion.identity);
            DontDestroyOnLoad(musicManager);
        }

        if (!GameObject.FindGameObjectWithTag("FlowManager"))
        {
            GameObject flowManager = Instantiate(m_FlowManager, transform.position, Quaternion.identity);
            DontDestroyOnLoad(flowManager);
        }

        if (!GameObject.FindGameObjectWithTag("LocalizationData") && m_LocalizationData != null)
        {
            GameObject localizationData = Instantiate(m_LocalizationData, transform.position, Quaternion.identity);
            DontDestroyOnLoad(localizationData);
        }
    }
}
