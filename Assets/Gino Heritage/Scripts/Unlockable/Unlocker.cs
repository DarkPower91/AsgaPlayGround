using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    [SerializeField]
    private Unlockable m_UnlockableType = Unlockable.Invalid;

    void Awake()
    {
        if(m_UnlockableType != Unlockable.Invalid && !SaveData.DexUnlockStatus.Contains(m_UnlockableType))
        {
            SaveData.DexUnlockStatus.Add(m_UnlockableType);
        }
    }
}
