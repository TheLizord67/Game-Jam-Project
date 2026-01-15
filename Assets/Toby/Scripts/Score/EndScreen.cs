using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Animator sceneTransition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sceneTransition.SetBool("SwitchScene", true);
        scoreText.text = Score.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
