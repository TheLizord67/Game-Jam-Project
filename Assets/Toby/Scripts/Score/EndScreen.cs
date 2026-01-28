using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int finalScore;
    [SerializeField] private List<GameObject> people;

    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource fade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        win.Play();
        GameObject person = people[Random.Range(0, people.Count)];
        person.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (win.isPlaying == false && fade.isPlaying == false)
        {
            fade.Play();
        }
        finalScore += 1;
        if (finalScore > Score.score)
        {
            Debug.Log("New High Score!");
        }
        else
        {
            scoreText.text = finalScore.ToString();
        }
    }
}
