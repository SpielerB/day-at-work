using System.Diagnostics.CodeAnalysis;
using Assets.Scripts.SelectableObject.Interactions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.SelectableObject
{
    /**
     * This class manages selectable objects
     */
    public class Selectable : MonoBehaviour
    {

        private Color normColor = Color.white;
        private float normWidth;

        private Color hoverColor;
        private float hoverWidth;
        private bool active;
        private bool isLookedAt;

        private Outline outline;
        private IInteraction interaction;

        [SuppressMessage("ReSharper", "UnusedMember.Local")]
        private void Start()
        {
            // Due to a bug in the Outline code, we can't simply inherit outline,
            // we have to add and enable/disable it to make it invisible
            outline = gameObject.AddComponent<Outline>();
            outline.enabled = true;
            normColor = outline.OutlineColor;
            normWidth = outline.OutlineWidth;
            hoverWidth = normWidth + 5;
            hoverColor = new Color(normColor.r, normColor.g + 1, normColor.b);

            interaction = GetComponent<IInteraction>();

            var trigger = gameObject.AddComponent<EventTrigger>();
            var pointerEnter = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
            pointerEnter.callback.AddListener(d => LookAt(true));
            trigger.triggers.Add(pointerEnter);

            var pointerExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
            pointerExit.callback.AddListener(d => LookAt(false));
            trigger.triggers.Add(pointerExit);

            var pointerClick = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
            pointerClick.callback.AddListener(d => PointerClick());
            trigger.triggers.Add(pointerClick);
        }

        /**
         * Updates the outline for the current object based on the outline mode and other variables
         */
        private void UpdateOutline()
        {
            var hideOutline = active
                              || !interaction.CanActivate() && interaction.OutlineMode == OutlineMode.ActivatableOnly
                              || interaction.OutlineMode == OutlineMode.HoverOnly && (!isLookedAt || !interaction.CanActivate());
                              
            if (hideOutline)
            {
                if (outline.enabled) outline.enabled = false;
                return;
            }
            if (!outline.enabled) outline.enabled = true;

            if (isLookedAt && interaction.CanActivate())
            {
                outline.OutlineColor = hoverColor;
                outline.OutlineWidth = hoverWidth;
            }
            else
            {
                outline.OutlineColor = normColor;
                outline.OutlineWidth = normWidth;
            }
        }

        protected void Update()
        {
            if (active && !interaction.IsActive())
            {
                active = false;
            }
            UpdateOutline();
        }

        /**
         * Used to change the current outline state
         */
        public void LookAt(bool isLookingAt)
        {
            isLookedAt = isLookingAt;
            UpdateOutline();
        }

        /**
         * OnPointClickEventHandler
         */
        public void PointerClick()
        {
            if (active || !interaction.CanActivate()) return;
            interaction.Activate();
            active = true;
            outline.enabled = false;
            UpdateOutline();
        }

    }
}