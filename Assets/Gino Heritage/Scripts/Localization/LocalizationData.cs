using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalizationData  
{
    private static Dictionary<string, string> dict = new Dictionary<string, string>();
    private static bool isIta = true;

    public static string GetDescription(string key)
    {
        dict = isIta ? ReadCSV.getDictIta() : ReadCSV.getDictEng();

        if (dict.ContainsKey(key)) 
        {
            return dict[key];
        } 
        else 
        {
            return key;
        }
    }

    public static bool IsIta
    {
        set 
        {
            isIta = value;
        }
        get 
        {
            return isIta;
        }
    }
}
