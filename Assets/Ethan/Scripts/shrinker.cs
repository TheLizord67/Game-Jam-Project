using Unity.VisualScripting;
using UnityEngine;

public class shrinker : MonoBehaviour
{
    public float difficulty = 1f;
    public float t = 0.0f;
    private float min = 0.6f;
    private float max = 3f;
    public GameObject parentBeat;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        this.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.localScale = new Vector3(Mathf.Lerp(max, min, t), Mathf.Lerp(max, min, t), 0);
        t += difficulty * Time.deltaTime;
        if (this.gameObject.transform.localScale == new Vector3(0.6f, 0.6f, 0))
        {
            t = 0f;
            Destroy(parentBeat.gameObject);
        }
    }
}
