using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockablePageText : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Locked = null;
    [SerializeField]
    private GameObject m_Unlocked = null;

    [SerializeField]
    private List<Unlockable> m_Lock = new List<Unlockable>();

    void OnEnable()
    {
        bool unlocked = false;
        foreach(Unlockable Lock in m_Lock)
        {
            unlocked |= SaveData.DexUnlockStatus.Contains(Lock);
        }

        m_Unlocked.SetActive(unlocked);
        m_Locked.SetActive(!unlocked);
    }
}
