using UnityEngine;
using System.Collections;

public class mouseFollow : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool yesIndeed = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("yuhh");
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.GetComponentInParent<Transform>().position = mousePosition;
        }
    }
}
