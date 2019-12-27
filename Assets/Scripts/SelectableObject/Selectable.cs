using Assets.Scripts.SelectableObject.Interactions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.SelectableObject
{
    public class Selectable : Outline
    {
        private Color normColor = Color.white;
        private float normWidth;

        private Color spezColor;
        private float spezWidth;
        private bool active;
        private bool isLookedAt;

        private Selectable selected;
        private IInteraction interaction;

        private void Start()
        {
            selected = GetComponent<Selectable>();
            normColor = selected.OutlineColor;
            normWidth = selected.OutlineWidth;
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
                selected.OutlineWidth = 0;
            }
            else if (isLookedAt && interaction.CanActivate())
            {
                selected.OutlineColor = spezColor;
                selected.OutlineWidth = spezWidth;
            }
            else
            {
                selected.OutlineColor = normColor;
                selected.OutlineWidth = normWidth;
            }
        }

        protected override void Update()
        {
            if (active && !interaction.IsActive())
            {
                active = false;
            }
            UpdateOutline();
            base.Update();
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
            UpdateOutline();

        }

    }
}