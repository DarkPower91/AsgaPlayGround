using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{

    public Sprite spriteIta;
    public Sprite spriteEng;
    private Image actualSprite;

    void Start()
    {
        actualSprite = GetComponent<Image>();
        SetSprite();
    }

    public void SwitchLanguage()
    {
        LocalizationData.IsIta = !LocalizationData.IsIta;
        SetSprite();
    }
    private void SetSprite() 
    {
        actualSprite.sprite = (LocalizationData.IsIta) ?  spriteIta :  spriteEng;
        GameplayEvents.OnLanguageChange();
    }
}
