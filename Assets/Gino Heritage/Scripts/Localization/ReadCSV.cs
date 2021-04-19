using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class ReadCSV 
{
    private static string csvPath =  "Languages/";
    private static string csvFileName = "Languages";
    private static Dictionary<string, string> dictEng = new Dictionary<string, string>();
    private static Dictionary<string, string> dictIta =  new Dictionary<string, string>();
    private static bool isInitalized = false;

    private static string getPathToCsv() 
    {
        return csvPath + csvFileName;
    }

    private static void readCSV()
    {
        string path = getPathToCsv();

        TextAsset extractedText  =  Resources.Load<TextAsset>(path);
        if (extractedText != null)
        {
            string fileData = extractedText.text;
            string[] lines = fileData.Split('\n');

            if (lines.Length > 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] lineData = lines[i].Split(';'); // set the right separator

                    if (lineData.Length == 3)
                    {
                        string key = lineData[0];
                        string descriptionEng = lineData[1];
                        string descriptionIta = lineData[2];

                        dictEng.Add(key, descriptionEng);
                        dictIta.Add(key, descriptionIta);
                    }
                }
            }

            isInitalized = true;
        }
        else
        {
            Assert.IsTrue(false, "Localization data not found at path " + path);
        }
    }

    public static Dictionary<string, string> getDictEng() 
    {
        if(!isInitalized) 
        {
            readCSV();
        } 
        return dictEng; 
    }

    public static Dictionary<string, string> getDictIta() 
    {
        if(!isInitalized) 
        {
            readCSV();
        }
        return dictIta;
    }
}
