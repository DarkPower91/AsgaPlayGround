using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DexManager : MonoBehaviour
{
    public List<GameObject> m_DexPages;

    private int m_CurrentActivePanel = 0;
    private int m_NumberOfPanels = 0;
    void Start()
    {
        m_NumberOfPanels  = m_DexPages.Count;
        if(m_NumberOfPanels>0)
        {
            foreach(GameObject page in m_DexPages)
            {
                page.SetActive(false);
            }
            m_DexPages[m_CurrentActivePanel].SetActive(true);
        }   
    }

    public void NextPage()
    {
        if(m_DexPages.Count>0)
        {
            m_DexPages[m_CurrentActivePanel].SetActive(false);
            m_CurrentActivePanel = (m_CurrentActivePanel + 1) % m_NumberOfPanels;
            m_DexPages[m_CurrentActivePanel].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if(m_DexPages.Count>0)
        {
            m_DexPages[m_CurrentActivePanel].SetActive(false);
            m_CurrentActivePanel = ((m_CurrentActivePanel - 1) + m_NumberOfPanels) % m_NumberOfPanels;
            m_DexPages[m_CurrentActivePanel].SetActive(true);
        }
    }

}
