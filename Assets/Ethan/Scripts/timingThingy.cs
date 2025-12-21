using UnityEngine;

public class timingThingy : MonoBehaviour
{
    public float speed;
    private bool beatStart = false;
    public GameObject shrinker;
    public GameObject outer;
    public GameObject inner;

    private float min = 0.5f;
    private float max = 2.0f;

    static float t = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        beatStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (beatStart)
        {
            shrinker.gameObject.transform.localScale = new Vector3(Mathf.Lerp(max, min, t), Mathf.Lerp(max, min, t), 0);
            t += speed * Time.deltaTime;
        }
    }
}
