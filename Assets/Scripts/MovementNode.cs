using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementNode : MonoBehaviour
{

    public Image interactionTimerIndicator;
    public PlayerController player;
    [Tooltip("How many seconds until the player moves to this MovementPoint")]
    public float movementDelay = 2f;
    
    private float step;
    private float timer;
    private bool lookingAt;

    private void Start()
    {
        step = 1f / movementDelay;
    }

    private void Update()
    {
        if (!lookingAt || interactionTimerIndicator == null) return;
        interactionTimerIndicator.fillAmount += step * Time.deltaTime;
        if (timer <= movementDelay)
        {
            timer += Time.deltaTime;
            return;
        }
        player.MoveTo(this);
        SetLookingAt(false);
        interactionTimerIndicator.fillAmount = 0;
    }

    public void SetLookingAt(bool look)
    {
        lookingAt = look;
        timer = 0;
        if (interactionTimerIndicator != null)
        {
            interactionTimerIndicator.fillAmount = 0;
        }
    }

}
