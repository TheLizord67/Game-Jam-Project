using UnityEngine;

public class devSpawnBeat : MonoBehaviour
{
    public GameObject prefab;
    public int targetFPS = 60;
    

    void Awake()
    {
        Score.difficulty = 2f;
        // VSync must be disabled for targetFrameRate to work
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }
    public void spawnBeat()
    {


        Instantiate(prefab, new Vector3(Random.Range(-7f, 7f), Random.Range(-2f, 3f), 670), transform.rotation);


    }
}
