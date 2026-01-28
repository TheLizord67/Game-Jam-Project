using UnityEngine;

public class devSpawnBeat : MonoBehaviour
{
    public GameObject prefab;
    public int targetFPS = 60;
    

    void Awake()
    {
        Score.difficulty = 1f;
        // VSync must be disabled for targetFrameRate to work
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }
    public void spawnBeat()
    {
        
        Instantiate(prefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 5f), 0), transform.rotation);
        
    }
}
