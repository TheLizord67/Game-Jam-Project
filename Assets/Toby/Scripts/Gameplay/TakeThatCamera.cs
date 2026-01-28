using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeThatCamera : MonoBehaviour
{
    [SerializeField] public GameObject goToObject;
    [SerializeField] public List<GameObject> cameraAngles;
    [SerializeField] public float switchTime;
    [SerializeField] public float switchTimer;
    [SerializeField] public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    public void Update()
    {
        if (switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
        }
        if (switchTimer <= 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, cameraAngles.Count);
            mainCamera.gameObject.GetComponent<SmoothCameraFollow>().target = cameraAngles[randomIndex].transform;
            switchTimer = switchTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.gameObject.GetComponent<SmoothCameraFollow>().target = this.transform;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.gameObject.GetComponent<SmoothCameraFollow>().target = goToObject.transform;
        }
    }
}
