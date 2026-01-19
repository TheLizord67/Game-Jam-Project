using UnityEngine;

public class devSpawnBeat : MonoBehaviour
{
    public GameObject prefab;
    public float min;
    public float max;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 0), transform.rotation);
        }
    }
}
