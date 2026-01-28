using UnityEngine;

public class dissapear : MonoBehaviour
{
    private float dissapearTime = 1.0f;
    // Update is called once per frame
    void Update()
    {
        dissapearTime -= Time.deltaTime;
        if( dissapearTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
