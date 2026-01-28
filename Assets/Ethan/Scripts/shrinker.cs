using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class shrinker : MonoBehaviour
{
    public float t = 0.0f;
    private float min = 0.6f;
    private float max = 3f;
    public GameObject parentBeat;
    private float initialTime;


    public string jsonFile;
    protected Song song;

    // Base format, JSON file needs all these variables
    [System.Serializable]
    public class Song
    {
        public float BPM;
        public int[] timeSig;
        // Level beats in timing
        public Dictionary<float, string> beatTiming;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        jsonFile = System.IO.File.ReadAllText(Application.dataPath + "/Josh/level files/text.json");
        song = JsonConvert.DeserializeObject<Song>(jsonFile);
        this.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        initialTime = Time.time;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        // it takes 4 beats for the shrinker to go from 3 to .6 with difficulty 1
        // therefore the shrinker should be spawned in 10/3 beats before it must be clicked, with difficulty 1
        // (10/3)/difficulty for how long before the beat to spawn it in

        t = Score.difficulty * (Time.time - initialTime) * 60/song.BPM;
        this.gameObject.transform.localScale = new Vector3(Mathf.Lerp(max, min, t), Mathf.Lerp(max, min, t), 0);
    }
}
