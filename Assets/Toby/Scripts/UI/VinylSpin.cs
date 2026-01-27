using NUnit.Framework;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTransition == false)
        {
            vinylTransform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }
        if (isTransition == true)
        {
            if (transitionTime > 0) 
            { 
                transitionTime -= Time.deltaTime;
                spinSpeed += 20;
                vinylTransform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
            }
            if (transitionTime <= 0f)
            {
                vinylAnimator.SetBool("isTransition", true);
                turnOffTime -= Time.deltaTime;
                vinylTransform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
                if (turnOffTime <= 0f)
                {
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
        isTransition = true;
        spinSpeed = 0f;
    } 
}
