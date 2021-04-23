using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalizationData  
{
    public static bool IsIta { set; get; } = true;

    private static Dictionary<string, string> dict = new Dictionary<string, string>();

    public static string GetDescription(string key)
    {
        dict = IsIta ? ReadCSV.getDictIta() : ReadCSV.getDictEng();

        if (dict.ContainsKey(key))
        {
            return dict[key];
        } 
        else 
        {
            return key;
        }
    }
}
