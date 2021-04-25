using System;
using UnityEngine.Events;

[System.Serializable]
public class HealthChangeEvent : UnityEvent<float> { }

public class GameplayEvents 
{
    public static Action LanguageChange = null;
    public static HealthChangeEvent HealthChange = null;

    public static void OnLanguageChange()
    {
        LanguageChange?.Invoke();
    }

    public static void OnHealthChange(float new_health) 
    {
        HealthChange?.Invoke(new_health);
    }
}
