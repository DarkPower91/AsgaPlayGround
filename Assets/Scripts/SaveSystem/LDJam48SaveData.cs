using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDJam48SaveData : Savable
{
    #region Savable fields
    /// <summary>
    /// Insert here the values to be saved
    /// and Generate Getters if needed
    /// - private static TYPE _NAME
    /// - public static TYPE NAME => _NAME  (this generates a getter only)
    /// or, instead of the two, just use this:
    /// - public static TYPE NAME { get; set; };
    /// </summary>
    #endregion

    #region Save keys
    /// <summary>
    /// Define the string key to save values, like:
    /// - private readonly string KEYNAME = "NAME";
    /// </summary>
    #endregion

    protected override void OnSave()
    {
        SaveEvents.OnDataUpdateNeeded();

        /// Example code of a save
        /// SaveLoad.Save<TYPE>(_NAME, KEYNAME);
    }

    protected override void OnLoad()
    {
        /// Example code of a load
        /// if (SaveLoad.SaveExist(KEYNAME))
        /// {
        ///     ftue = SaveLoad.Load<TYPE>(_NAME);
        /// }
    }
}