using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    [SerializeField]
    private Unlockable m_UnlockableType = Unlockable.Invalid;

    private void Awake()
    {
        if(m_UnlockableType != Unlockable.Invalid && !GinoSaveData.DexUnlockStatus.Contains(m_UnlockableType))
        {
            GinoSaveData.DexUnlockStatus.Add(m_UnlockableType);
        }
    }
}
