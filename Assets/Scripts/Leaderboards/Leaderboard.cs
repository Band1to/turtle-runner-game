using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour {

    const string privateCode = "_wZlnKtsvUGlEfZ0HwUaTQ-Ce26fF9Wky1WrGrNSDpDw";
    const string publicCode = "5a7f314839992d09e4c72a3c";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    DisplayLeaderboard highscoresDisplay;

    static Leaderboard instance;

    void Awake()
    {
        instance = this;
        highscoresDisplay = GetComponent<DisplayLeaderboard>();
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewScore(username, score));
    }

    //Uploads a new Highscore with the provided username and score.
    //Then downloads a copy of the Leaderboard to ensure data is synced.
    IEnumerator UploadNewScore(string username, int score)
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
        StartCoroutine(DownloadScores());
    }

    //Downloads the current Leaderboard.
    IEnumerator DownloadScores()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatScores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error downloading: " + www.error);
        }
    }

    void FormatScores(string textStream)
    {
        //Breaks each Score entry into individual strings
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        //Breaks the username and score of each entry into seperate variables.
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }


}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}