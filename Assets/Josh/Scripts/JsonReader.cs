using System.Collections.Generic;
using System.Net;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JsonReader : MonoBehaviour
{

    public TextAsset jsonFile;


    // Base format, JSON file needs all these variables
    [System.Serializable]
    public class Song
    {
        public float BPM;
        public int[] timeSig;
        // Level beats in timing
        public Dictionary<float, string> beatTiming;
    }

    public Song song = new Song();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        song = JsonConvert.DeserializeObject<Song>(jsonFile.text);

    }

    public void outputJSON(Song thisSong)
    {

        string strOutput = JsonConvert.SerializeObject(thisSong, Formatting.Indented);
        File.WriteAllText(Application.dataPath + "/Josh/level files/text.json", strOutput);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
