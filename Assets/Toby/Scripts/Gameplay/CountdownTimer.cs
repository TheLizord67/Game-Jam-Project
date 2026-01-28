using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private List<GameObject> whatToActivate;
    [SerializeField] private GameObject countdownObject;
    [SerializeField] private Animator numberAnimator;
    [SerializeField] private float countdownTime;
    [SerializeField] private float timeBetweenNumbers;
    [SerializeField] private TextMeshProUGUI countdownText;

    [SerializeField] private AudioSource countdownOne;
    [SerializeField] private AudioSource countdownTwo;
    [SerializeField] private AudioSource countdownThree;
    [SerializeField] private AudioSource countdownGo;
    [SerializeField] private BeatPlayer beatPlayerRef;
    void Start()
    {
        timeBetweenNumbers = 120 / JsonConvert.DeserializeObject<BeatPlayer.Song>(beatPlayerRef.songFile.text).BPM;
        countdownOne.Play();
        countdownText.text = "3";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(Two());
        StartCoroutine(SongStart());
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public IEnumerator SongStart()
    {
        yield return new WaitForSeconds(timeBetweenNumbers * 4 - timeBetweenNumbers * 2 / Score.difficulty);
        beatPlayerRef.startSong();
    }
    public IEnumerator Two()
    {
        yield return new WaitForSeconds(timeBetweenNumbers);
        countdownTwo.Play();
        countdownText.text = "2";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(One());
    }
    public IEnumerator One()
    {
        yield return new WaitForSeconds(timeBetweenNumbers);
        countdownThree.Play();
        countdownText.text = "1";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(Go());
    }

    public IEnumerator Go()
    {
        yield return new WaitForSeconds(timeBetweenNumbers);
        countdownGo.Play();
        countdownText.text = "GO!";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(CountdownTurnOff());
    }
    public IEnumerator CountdownTurnOff()
    {
        yield return new WaitForSeconds(timeBetweenNumbers);
        countdownObject.SetActive(false);
        foreach (GameObject activate in whatToActivate)
        {
            activate.SetActive(true);
        }
        this.enabled = false;
    }
}
