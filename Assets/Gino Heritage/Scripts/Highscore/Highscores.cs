using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour
{
    private const string privateCode = "9neaXpcCLkOtXdYOhchXSQNbTc82Ba8E6tN1wFCJXtXg";
    private const string publicCode = "5f77586deb371809c45e43fe";
    private const string webURL = "http://dreamlo.com/lb/";
    private DisplayHighscores highscoreDisplay;

    public Highscore[] highscoresList;
    static Highscores instance;

    private void Awake()
	{
        highscoreDisplay = GetComponent<DisplayHighscores>();
        instance = this;
	}

    public static void AddNewHighscore(string username, float score)
	{
        int scoreInt = (int)(score * 1000000);
        AddNewHighscore(username, scoreInt);
	}

    private static void AddNewHighscore(string username, int score)
	{
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighscores();
		}
		else
        {
            print("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores()
	{
        StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoreDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
		{
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            float scoreFloat = (float)score / 1000000;
            highscoresList[i] = new Highscore(username, scoreFloat);
		}
	}
}

public struct Highscore
{
    public string username;
    public float score;

    public Highscore(string _username, float _score)
	{
        username = _username;
        score = _score;
	}
}