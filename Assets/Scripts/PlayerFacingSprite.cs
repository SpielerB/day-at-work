using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerFacingSprite : MonoBehaviour
{

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
