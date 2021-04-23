using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GinoSaveData : Savable
{
    private static List<Unlockable> _DexUnlockStatus = new List<Unlockable>();
    private static List<float> _HighestScores = new List<float>();

    public static bool ftue { get; set; } = true;

    public static List<Unlockable> DexUnlockStatus => _DexUnlockStatus;
    public static List<float> HighestScores => _HighestScores;

    private readonly string dexKey = "Dex";
    private readonly string scoreKey = "Scores";
    private readonly string ftueKey = "PlayerProfile";

    protected override void OnSave()
    {
        SaveEvents.OnDataUpdateNeeded();

        SaveLoad.Save<List<Unlockable>>(_DexUnlockStatus, dexKey);
        SaveLoad.Save<List<float>>(_HighestScores, scoreKey);
        SaveLoad.Save<bool>(ftue,ftueKey);
    }

    protected override void OnLoad()
    {
        if(SaveLoad.SaveExist(ftueKey))
        {
            ftue = SaveLoad.Load<bool>(ftueKey);
        }
        if(SaveLoad.SaveExist(dexKey))
        {
            _DexUnlockStatus = SaveLoad.Load<List<Unlockable>>(dexKey);
        }
        if(SaveLoad.SaveExist(scoreKey))
       {
            _HighestScores = SaveLoad.Load<List<float>>(scoreKey);
       } 
    }
}
