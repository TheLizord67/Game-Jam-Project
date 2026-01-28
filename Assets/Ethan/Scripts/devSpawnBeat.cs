using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class devSpawnBeat : MonoBehaviour
{
    public GameObject prefab;
    public int targetFPS = 60;
    public ArrayList beats;
    private bool intersecting;
    

    void Awake()
    {
        Score.difficulty = 1.5f;
        // VSync must be disabled for targetFrameRate to work
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
        beats = new ArrayList();
    }
    public void spawnBeat()
    {


        GameObject nextBeat = Instantiate(prefab, new Vector3(Random.Range(-7f, 7f), Random.Range(-2f, 3f), 670), transform.rotation);
        beats.Add(nextBeat);
        intersecting = true;
        while (intersecting)
        {
            intersecting = false;
            foreach (GameObject beat in beats)
            {
                if (beat)
                {
                    if (beat.GetComponent<CircleCollider2D>().IsTouching(nextBeat.GetComponent<CircleCollider2D>()) && beat != nextBeat)
                    {
                        nextBeat.transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-2f, 3f), 670);
                        intersecting = true;
                    }
                }
            }
        }


    }
}
