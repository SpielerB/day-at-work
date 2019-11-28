using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementNode : MonoBehaviour
{
    public Image interactionTimerIndicator;
    [Tooltip("How many seconds until the player moves to this MovementPoint")]
    public float movementDelay = 1.5f;
    
    private float step;
    private float timer;
    private bool lookingAt;
    private PlayerController player;

    private void Start()
    {
        step = 1f / movementDelay;
        player = FindObjectOfType<PlayerController>();

        var trigger = gameObject.AddComponent<EventTrigger>();
        var pointerEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
        pointerEnter.callback.AddListener(d => LookAt(true));
        trigger.triggers.Add(pointerEnter);

        var pointerExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
        pointerExit.callback.AddListener(d => LookAt(false));
        trigger.triggers.Add(pointerExit);
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
        LookAt(false);
        interactionTimerIndicator.fillAmount = 0;
    }

    public void LookAt(bool look)
    {
        lookingAt = look;
        timer = 0;
        if (interactionTimerIndicator != null)
        {
            interactionTimerIndicator.fillAmount = 0;
        }
    }
}