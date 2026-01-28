using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 regularPosition;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [ContextMenu("Set Regular")]
    public void SetOffset()
    {
        regularPosition = target.position;
    }

    [ContextMenu("Set Offset")]
    public void SetMovePosition()
    {
        offset = target.position;
    }

    [ContextMenu("Reset Position")]

    public void ResetPosition()
    {
        target.position = regularPosition;
    }
    void Start()
    {
        regularPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position == regularPosition && move == false)
        {
            move = true;
        }
        if (move)
        {
            target.position = Vector3.MoveTowards(target.position, offset, moveSpeed * Time.deltaTime);
            if (target.position == offset)
            {
                move = false;
            }
        }
        if (move == false && target.position != regularPosition)
        {
            target.position = Vector3.MoveTowards(target.position, regularPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void OnDisable()
    {
        target.position = regularPosition;
    }
}
