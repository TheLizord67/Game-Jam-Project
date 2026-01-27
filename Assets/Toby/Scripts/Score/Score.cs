using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public static int score;
    [SerializeField] public static float difficulty;
    [SerializeField] public static string difficultyName;
    [SerializeField] private TextMeshProUGUI scoreText;

    [ContextMenu("+10 Score")]
    public void AddScore10()
    {
        score += 10;
        Debug.Log($"Score increased by 10. New score: {score}");
    }
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {score}";
    }
}
