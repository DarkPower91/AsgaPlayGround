using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour
{
    public Text[] highscoreFields;
    private Highscores highscoresManager;

    private void Start()
	{
        for (int i = 0; i < highscoreFields.Length; i++)
		{
            highscoreFields[i].text = ". Fetching...";
        }

        highscoresManager = GetComponent<Highscores>();
        StartCoroutine("RefreshHighscores");
	}

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
	{
        for (int i = 0; i < highscoreFields.Length; i++)
		{
            highscoreFields[i].text = "";
            if (i < highscoreList.Length)
            {
                highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
		}
	}

    IEnumerator RefreshHighscores()
	{
        while (true)
		{
            highscoresManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
		}
	}
}