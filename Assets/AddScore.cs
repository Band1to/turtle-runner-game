using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {
    //Generates a random username and score before uploading to the Leaderboards
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int score = Random.Range(0, 100);
            string username = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < Random.Range(5, 10); i++)
            {
                username += alphabet[Random.Range(0, alphabet.Length)];
            }
            Leaderboard.AddNewHighscore(username, score);
        }
    }
}
