using System;

public class GameplayEvents 
{
    public static Action LanguageChange = null;

    public static void OnLanguageChange()
    {
        LanguageChange?.Invoke();
    }
}
