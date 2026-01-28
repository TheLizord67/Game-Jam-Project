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
    [SerializeField] private float countdownTime = 3f;
    [SerializeField] private float timeBetweemNumbers;
    [SerializeField] private TextMeshProUGUI countdownText;

    [SerializeField] private AudioSource countdownOne;
    [SerializeField] private AudioSource countdownTwo;
    [SerializeField] private AudioSource countdownThree;
    [SerializeField] private AudioSource countdownGo;
    void Start()
    {
        countdownOne.Play();
        countdownText.text = "3";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(Two());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public IEnumerator Two()
    {
        yield return new WaitForSeconds(timeBetweemNumbers);
        countdownTwo.Play();
        countdownText.text = "2";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(One());
    }
    public IEnumerator One()
    {
        yield return new WaitForSeconds(timeBetweemNumbers);
        countdownThree.Play();
        countdownText.text = "1";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(Go());
    }

    public IEnumerator Go()
    {
        yield return new WaitForSeconds(timeBetweemNumbers);
        countdownGo.Play();
        countdownText.text = "GO!";
        numberAnimator.Play("CountdownTimer");
        StartCoroutine(CountdownTurnOff());
    }
    public IEnumerator CountdownTurnOff()
    {
        yield return new WaitForSeconds(timeBetweemNumbers);
        countdownObject.SetActive(false);
        foreach (GameObject activate in whatToActivate)
        {
            activate.SetActive(true);
        }
        this.enabled = false;
    }
}
