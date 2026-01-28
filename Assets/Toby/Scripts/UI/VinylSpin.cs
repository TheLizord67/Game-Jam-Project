using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylSpin : MonoBehaviour
{
    [SerializeField] private Transform vinylTransform;
    [SerializeField] private float spinSpeed = 10f;
    
    [SerializeField] private float transitionTime;
    [SerializeField] private float turnOffTime;

    [SerializeField] List<GameObject> toTurnOff;
    [SerializeField] private bool isTransition;
    [SerializeField] private Animator vinylAnimator;

    [SerializeField] private UIButton uiButton;
    [SerializeField] private string songScene;

    [SerializeField] private AudioSource vinylWind;
    [SerializeField] private AudioSource vinylLeave;
    [SerializeField] private AudioSource vinylBack;
    [SerializeField] private AudioSource song;

    [SerializeField] private List<GameObject> checkmarks;
    [SerializeField] private GameObject reminder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTransition == false)
        {
            vinylTransform.Rotate(Vector3.back * spinSpeed * Time.deltaTime);
        }
        if (isTransition == true)
        {
            if (transitionTime > 0) 
            { 
                transitionTime -= Time.deltaTime;
                spinSpeed += 20;
                vinylTransform.Rotate(Vector3.back * spinSpeed * Time.deltaTime);
            }
            if (transitionTime <= 0f)
            {
                vinylWind.Stop();
                if (vinylLeave.isPlaying == false)
                {
                    vinylLeave.Play();
                }
                vinylAnimator.SetBool("isTransition", true);
                turnOffTime -= Time.deltaTime;
                vinylTransform.Rotate(Vector3.back * spinSpeed * Time.deltaTime);
                if (turnOffTime <= 0f)
                {
                    if (vinylBack.isPlaying == false)
                    {
                        vinylBack.Play();
                    }
                    foreach (GameObject obj in toTurnOff)
                    {
                        obj.SetActive(false);
                    }
                    
                    uiButton.LoadScene(songScene);
                }
            }
        }
    }

    public void Transition()
    {
        foreach (GameObject checkmark in checkmarks)
        {
            if (checkmark.activeSelf == true)
            {
                song.volume = 0.5f;
                vinylWind.Play();
                isTransition = true;
                spinSpeed = 0f;
                return;
            }
        }
        foreach (GameObject checkmark in checkmarks)
        {
            if (checkmark.activeSelf == false)
            {
                reminder.SetActive(true);
                StartCoroutine(reminderTurnOff());
            }
        }
    } 
    public IEnumerator reminderTurnOff()
    {
        yield return new WaitForSeconds(1f);
        reminder.SetActive(false);

    }

}
