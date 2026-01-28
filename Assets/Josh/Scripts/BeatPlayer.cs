using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class BeatPlayer : MonoBehaviour
{

    public TextAsset songFile;

    [System.Serializable]
    public class Song
    {
        public float BPM;
        public int[] timeSig;
        // Level beats in timing
        public Dictionary<float, string> beatTiming;
    }

    public Song song;
    public float currentBeat = 1;
    public int currentEnum = 0;
    public float initialTime;
    public float[] timings;
    public string[] beats;
    public bool songStarted = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        song = JsonConvert.DeserializeObject<Song>(songFile.text);
        timings = song.beatTiming.Keys.ToArray();
    }

    void startSong()
    {
        initialTime = Time.time;
        songStarted = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (songStarted)
        {
            //                             beat transformed to seconds
            if (Time.time - initialTime >= 60 * (currentBeat - 1)/song.BPM)
            {
                if (song.beatTiming[currentBeat] == "1") spawnBeat();
                currentEnum++;
                try
                {
                    currentBeat = timings[currentEnum];
                }
                finally
                { if (Time.time - initialTime >= currentBeat) currentBeat = 1000000; }

            }
        }
    }

    void spawnBeat()
    {

    }
}
