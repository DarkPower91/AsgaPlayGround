using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions;

public class LocalizationKey : MonoBehaviour
{
    public string key = "";
    private Text shownText;
    private TMP_Text shownTextPro;

    private void Awake()
    {
        shownTextPro = GetComponent<TMP_Text>();
        shownText = GetComponent<Text>();
        GameplayEvents.LanguageChange += OnLanguageChange;
    }

    private void OnDestroy()
    {
        GameplayEvents.LanguageChange -= OnLanguageChange;
    }

    private void OnEnable()
    {
       OnLanguageChange();
    }

    private void OnLanguageChange()
    {
        // if exists, from its key, get the data from LocalizationData ; else return key
        string data = LocalizationData.GetDescription(key);
        if (shownTextPro != null)
        {
            shownTextPro.text = data;
        }
        else if (shownText != null)
        {
            shownText.text = data;
        }
        else
        {
            Assert.IsTrue(false, "[LOCALIZATION] Object " + gameObject.name + "has not Text or TextMesh component for the Localization key.");
        }
    }
}
