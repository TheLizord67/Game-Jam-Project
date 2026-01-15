using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;
public class Leaderboard : MonoBehaviour
{
    public Songs currentSong;
    public TMP_InputField nameInput;
    public string nameText;
    public int currentHighscore;
    public List<TextMeshProUGUI> namesText;
    public List<TextMeshProUGUI> scoresText;

    void Start()
    {
        foreach (var score in currentSong.leaderboard.scores)
        {
            if (Score.score > score)
            {
                SubmitName();
            }
            else
            {
                Debug.Log("Score not high enough for leaderboard");
                SetLeaderboard();
                break;
            }
        }
    }

    public void SubmitName()
    {
        nameText = nameInput.text; 
        currentHighscore = Score.score;
        foreach (var score in currentSong.leaderboard.scores)
        {
            if (currentHighscore > score)
            {
                currentSong.leaderboard.scores.Insert(currentSong.leaderboard.scores.IndexOf(score), currentHighscore);
                currentSong.leaderboard.scores.Remove(score);
                currentSong.leaderboard.names.Insert(currentSong.leaderboard.scores.IndexOf(score), nameText);
                currentSong.leaderboard.names.RemoveAt(currentSong.leaderboard.scores.IndexOf(score)+1);
            }
        }
        SetLeaderboard();
    }
    // Update is called once per frame
    public void SetLeaderboard()
    {
        for (int i = 0; i < currentSong.leaderboard.names.Count && i < namesText.Count; i++)
        {
            namesText[i].text = currentSong.leaderboard.names[i];
        }
        for (int i = 0; i < currentSong.leaderboard.scores.Count && i < scoresText.Count; i++)
        {
            scoresText[i].text = currentSong.leaderboard.scores[i].ToString();
        }
    }
    void Update()
    {
        
    }
}
