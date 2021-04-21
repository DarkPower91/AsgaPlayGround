using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlavourDefinition))]
public class ActivateGameOverFlavour : MonoBehaviour
{

    public GameObject m_MuonicCanvas = null;
    public GameObject m_ElectronicCanvas = null;
    public GameObject m_TauonicCanvas = null;


    private FlavourDefinition m_FlavourDefinition = null;
    void Start()
    {
        m_FlavourDefinition = GetComponent<FlavourDefinition>();
    }

    void Update()
    {
        if(m_FlavourDefinition != null)
        {
            switch(m_FlavourDefinition.flavour)
            {
                case Flavours.muonic:
                {
                    m_MuonicCanvas.SetActive(true);
                    break;
                }
                case Flavours.electronic:
                {
                    m_ElectronicCanvas.SetActive(true);
                    break;
                }
                case Flavours.tauonic:
                {
                    m_TauonicCanvas.SetActive(true);
                    break;
                }
            }
        }
    }
}
