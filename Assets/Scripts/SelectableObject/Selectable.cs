using Assets.Scripts.SelectableObject.Interactions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.SelectableObject
{
    public class Selectable : MonoBehaviour
    {
        private Color normColor = Color.white;
        private float normWidth;

        private Color spezColor;
        private float spezWidth;
        private bool active;
        private bool isLookedAt;

        private Outline outline;
        private IInteraction interaction;

        private void Start()
        {
            // Due to a bug in the Outline code, we can't simply inherit outline,
            // we have to add and enable/disable it to make it invisible
            outline = gameObject.AddComponent<Outline>();
            normColor = outline.OutlineColor;
            normWidth = 20;
            spezWidth = normWidth + 5;
            spezColor = new Color(normColor.r, normColor.g + 1, normColor.b);
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

        private void UpdateOutline()
        {
            if (active || !interaction.CanActivate() && !interaction.IsAlwaysHighlighted())
            {
                if (outline.enabled) outline.enabled = false;
                return;
            }
            if (!outline.enabled) outline.enabled = true;

            if (isLookedAt && interaction.CanActivate())
            {
                outline.OutlineColor = spezColor;
                outline.OutlineWidth = spezWidth;
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

        public void LookAt(bool isLookedAt)
        {
            this.isLookedAt = isLookedAt;
            UpdateOutline();
        }

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