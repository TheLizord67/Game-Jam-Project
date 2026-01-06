using UnityEngine;

public class timingThingy : MonoBehaviour
{
    public float speed;
    private bool beatStart = false;
    public GameObject shrinker;
    public GameObject outer;
    public GameObject inner;

    private float min = 0.8f;
    private float max = 1.5f;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("beat"))
        {
            if (collision.gameObject.name == "Outer Circle")
            {

            }
        }
    }
}
