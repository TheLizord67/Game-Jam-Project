using UnityEngine;

public class newBeat : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("you're kidding me");
        gameObject.GetComponentInChildren<shrinker>().t = 0;
        Destroy(gameObject);
    }
}
