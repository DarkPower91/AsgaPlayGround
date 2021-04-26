using System;
using UnityEngine.Events;

[System.Serializable]
public class HealthChangeEvent : UnityEvent<float> { }

public class DeathEvent : UnityEvent { }

public class GameplayEvents 
{
    public static Action LanguageChange = null;
    public static HealthChangeEvent HealthChange = new HealthChangeEvent();
    public static DeathEvent DorasDeath = new DeathEvent();

    public static void OnLanguageChange()
    {
        LanguageChange?.Invoke();
    }

    public static void OnHealthChange(float new_health) 
    {
        HealthChange?.Invoke(new_health);
    }

    public static void OnDeath()
    {
        // What happens when you died
        DorasDeath?.Invoke();
    }
}
