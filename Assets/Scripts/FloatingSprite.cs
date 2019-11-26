using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSprite : MonoBehaviour
{
    public float amplitude = 0.0025f;
    public float frequency = 1f;

    private void Update()
    {
        transform.Translate(0, Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude, 0,  Space.World);
    }

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
