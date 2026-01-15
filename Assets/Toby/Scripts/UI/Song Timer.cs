using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SongTimer : MonoBehaviour
{
    [SerializeField] AudioSource songPlayer;
    [SerializeField] float songLength;
    [SerializeField] Slider timeSlider;
    [SerializeField] List<float> changeTimes;
    [SerializeField] List<bool> whatToSwitch;
    [SerializeField] GameObject guitarObject;
    [SerializeField] GameObject drumObject;
    [SerializeField] GameObject endScreen;
    [ContextMenu("SongLength")]
    public void SongLength()
    {
        songLength = songPlayer.clip.length;
    }
    void Start()
    { 
        timeSlider.maxValue = songPlayer.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        songLength = songPlayer.time;
        timeSlider.value = songLength;
        foreach (var t in changeTimes)
        {
            if (changeTimes.Count == 0)
            {
                OpenEndScreen();
                break;
            }
            if (songLength > t)
            {
                int index = changeTimes.IndexOf(t);
                changeTimes.RemoveAt(index);    
                if (whatToSwitch[index])
                {
                    SwitchToDrums();
                    whatToSwitch.RemoveAt(index);
                }
                else
                {
                    SwitchToGuitar(); 
                    whatToSwitch.RemoveAt(index);
                }

            }
            else
            {
                Debug.Log("No Switch");
            }
        }
    }

    public void OpenEndScreen()
    {
        endScreen.SetActive(true);
    }
    public void SwitchToGuitar()
    {
        guitarObject.SetActive(true);
        drumObject.SetActive(false);
        //Do Switching stuff
    }
    
    public void SwitchToDrums()
    {
        guitarObject.SetActive(false);
        drumObject.SetActive(true);
        //Do Switching stuff
    }


}
