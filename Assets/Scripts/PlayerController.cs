using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public MovementNode initialMovementPoint;

    public MovementNode CurrentMovementPoint { get; private set; }

    private void Start()
    {
        if (initialMovementPoint != null)
        {
            MoveTo(initialMovementPoint);
        }
    }

    public void ResetPosition()
    {
        if (initialMovementPoint != null)
        {
            MoveTo(initialMovementPoint);
        }
        else
        {
            transform.Translate(-transform.position.x, 0, -transform.position.z);
            CurrentMovementPoint = null;
        }
    }

    public void MoveTo(MovementNode point)
    {
        var target = point.transform.position;
        var origin = transform.position;
        transform.Translate(target.x - origin.x, 0, target.z - origin.z, Space.World);

        if (CurrentMovementPoint != null)
        {
            CurrentMovementPoint.gameObject.SetActive(true);
        }

        point.gameObject.SetActive(false);
        CurrentMovementPoint = point;
    }

    private void Update()
    {
#if UNITY_EDITOR
        // This is a workaround to use unity with remote desktop clients and still be able to turn around
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, Vector3.down, 40 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, Vector3.up, 40 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, 40 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.left, 40 * Time.deltaTime);
        }
#endif
    }
}