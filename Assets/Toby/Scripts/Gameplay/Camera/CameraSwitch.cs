using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras;
    [SerializeField] private float maxSwitchTime;
    [SerializeField] private float minSwitchTime;
    [SerializeField] private float switchTime;
    [SerializeField] private System.Random randyTheRandom = new System.Random();
    void Start()
    {
        ShuffleTimes();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchTime <= 0)
        {
            List<GameObject> cam = cameras.OrderBy(x => randyTheRandom.Next()).ToList();
            foreach (var c in cameras)
            {
                if (c == cam[0])
                {
                    c.SetActive(true);
                }
                else
                {
                    c.SetActive(false);
                }
            }
            ShuffleTimes();
        }
        else
        {
            switchTime -= Time.deltaTime;
        }
    }

    public void ShuffleTimes()
    {
        switchTime = Random.Range(minSwitchTime, maxSwitchTime);
    }
}
