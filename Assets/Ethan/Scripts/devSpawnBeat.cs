using UnityEngine;

public class devSpawnBeat : MonoBehaviour
{
    public GameObject prefab;
    public int targetFPS = 60;

    void Awake()
    {
        Score.difficulty = .75f;
        // VSync must be disabled for targetFrameRate to work
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 0), transform.rotation);
        }
    }
}
