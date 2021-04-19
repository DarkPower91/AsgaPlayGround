using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockablePageImage : MonoBehaviour
{
    [SerializeField]
    private Unlockable m_Lock = Unlockable.Invalid;

    private void OnEnable() 
    {
        Image sprite = GetComponent<Image>();
        sprite.color = SaveData.DexUnlockStatus.Contains(m_Lock) ? Color.white : Color.black;
    }
}
