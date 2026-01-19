using UnityEngine;
using System.Collections;

public class mouseFollow : MonoBehaviour
{
    private Vector3 mousePosition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = mousePos;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("yuhh");
        //    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    this.GetComponentInParent<Transform>().position = mousePosition;
        //}
    }
}
