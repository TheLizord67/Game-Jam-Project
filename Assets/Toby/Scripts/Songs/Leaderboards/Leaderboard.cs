using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;
public class Leaderboard : MonoBehaviour
{
    [SerializeField] public Songs currentSong;
    [SerializeField] public TMP_InputField nameInput;
    [SerializeField] public GameObject input;
    [SerializeField] public string nameText;
    [SerializeField] public int currentHighscore;
    [SerializeField] public List<TextMeshProUGUI> namesText;
    [SerializeField] public List<TextMeshProUGUI> scoresText;
    [SerializeField] public bool justPlayedSong = false;
    [SerializeField] public bool submittedName = false;
    void Start()
    {
        if (justPlayedSong == true)
        {
            foreach (var score in currentSong.leaderboard.scores)
            {
                if (Score.score > score)
                {
                    SubmitName();
                    return;
                }
                else
                {
                    Debug.Log("Score not high enough for this leaderboard spot");
                }
            }
        }
        else
        {
            SetLeaderboard();
        }
    }

    public void SubmitName()
    {
        input.SetActive(true);
        currentHighscore = Score.score;
    }
    public void NameTrue()
    {
        submittedName = true;
    }
    // Update is called once per frame
    public void SetLeaderboard()
    {
        submittedName = false;
        if (currentSong.leaderboard.names.Count > 10)
        {
            currentSong.leaderboard.names.Remove(currentSong.leaderboard.names[10]);
            currentSong.leaderboard.scores.Remove(currentSong.leaderboard.scores[10]);
        }
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
        if (submittedName == true)
        {
            nameText = nameInput.text;
            foreach (var score in currentSong.leaderboard.scores)
            {
                if (currentHighscore > score)
                {
                    currentSong.leaderboard.scores.Insert(currentSong.leaderboard.scores.IndexOf(score), currentHighscore);
                    currentSong.leaderboard.names.Insert(currentSong.leaderboard.scores.IndexOf(score) - 1, nameText);
                    submittedName = false;
                    SetLeaderboard();
                    return;
                }
                else
                {
                    Debug.Log("Not there");
                }
            }
            submittedName = false;
            SetLeaderboard();
        }
    }
}
