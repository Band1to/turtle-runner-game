using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLeaderboard : MonoBehaviour {

    public Text[] highscoreText;
    Leaderboard highscoreManager;

	void Start ()
    {
        //Inserts placeholder text that fills the leaderboard until scores are downloaded.
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Fetching...";
        }

        highscoreManager = GetComponent<Leaderboard>();

        StartCoroutine(RefreshHighscores());
	}

    //Formats the visual entry of each Leaderboard entry.
    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            //Ensures the '-' is only inserted for valid score entries. Otherwise is left blank.
            if (highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    //Updates the Leaderboard every 30 frames.
    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }

}
