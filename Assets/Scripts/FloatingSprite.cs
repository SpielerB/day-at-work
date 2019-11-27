using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSprite : MonoBehaviour
{
    public float amplitude = 0.25f;
    public float frequency = 1.25f;

    private Vector3 offset;
    private Vector3 position;

    private void Start()
    {
        offset = transform.position;
    }

    private void Update()
    {
        position = offset;
        position.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = position;
    }

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
