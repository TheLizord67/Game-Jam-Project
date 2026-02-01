 using UnityEngine;

public class newBeat : MonoBehaviour
{
    public GameObject shrinker;
    private string wordScore = "Oops...";
    private int tempScore = 0;

    public GameObject perfect;
    public GameObject good;
    public GameObject yeah;
    public GameObject oops;
    public GameObject abysmal;
    public float initialTime;


    public float t = 0.0f;
    private float min = 0.6f;
    private float max = 3f;


    private void Start()
    {
        initialTime = Time.time;
    }
    private void FixedUpdate()
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


        t = Score.difficulty * (Time.time - initialTime) * 60 / 140;

        shrinker.transform.localScale = new Vector3(Mathf.Lerp(max, min, t), Mathf.Lerp(max, min, t), 0);
        Debug.Log(t + " " + shrinker.transform.localScale.x);

        if (shrinker.transform.localScale.x > 1.36f)
        {
            wordScore = "Oops...";
            tempScore = 0;
        }
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
            Debug.Log(wordScore);
            Instantiate(abysmal, transform.position, Quaternion.identity);
            t = 0f;
            Destroy(this.gameObject);
        }

    }
    public void OnMouseDown()
    {
        if (shrinker.transform.localScale.x <= 2)
        {
            Debug.Log(wordScore);
            Score.score += tempScore * 10;
            if(wordScore == "Good!")
            {
                Instantiate(good, transform.position, Quaternion.identity);
            }
            if(wordScore == "Perfect!")
            {
                Instantiate(perfect, transform.position, Quaternion.identity);
            }
            if(wordScore == "Yeah!")
            {
                Instantiate(yeah, transform.position, Quaternion.identity);
            }
            if(wordScore == "Oops...")
            {
                Instantiate(oops, transform.position, Quaternion.identity);
            }
            if(wordScore == "abysmal...")
            {
                Instantiate(abysmal, transform.position, Quaternion.identity);
            }
            t = 0;
            Destroy(this.gameObject);
        }
    }
}
