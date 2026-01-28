 using UnityEngine;

public class newBeat : MonoBehaviour
{
    public GameObject shrinker;
    private string wordScore = "Oops...";
    private int tempScore = 0;
    private float initialTime;
    private void Start()
    {
        initialTime = Time.time;
    }
    private void Update()
    {
        //template
        //if (shrinker.transform.localScale == )
        //{
        //    /*
        //     * Scores are the number's listed and below before next score
        //        starts at 3, shrinks down to 0.6
        //        >1.36 = Oops...
        //        =<1.36 = Good!
        //        =<1.1 = Perfect!
        //        =<.76 = Yeah!
        //        =<.6 = Oops...
        //    */
        //}
        if (shrinker.transform.localScale.x <= 1.36f)
        {
            wordScore = "Good!";
            tempScore = 1;
        }
        if (shrinker.transform.localScale.x <= 1.1f)
        {
            wordScore = "Perfect!";
            tempScore = 3;
        }
        if (shrinker.transform.localScale.x <= .86f)
        {
            wordScore = "Yeah!";
            tempScore = 2;
        }
        if (shrinker.transform.localScale.x <= .7f)
        {
            wordScore = "Oops...";
            tempScore = 0;
        }
        if (shrinker.transform.localScale.x <= .6f)
        {
            wordScore = "abysmal...";
        }

        if (this.gameObject.transform.localScale == new Vector3(0.6f, 0.6f, 0))
        {
            Debug.Log(wordScore);
            gameObject.GetComponentInChildren<shrinker>().t = 0f;
            Destroy(gameObject);
        }
    }
    public void OnMouseDown()
    {
        Debug.Log(wordScore);
        gameObject.GetComponentInChildren<shrinker>().t = 0;
        Destroy(gameObject);
    }
}
