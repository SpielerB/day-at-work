using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : Outline
{
    private Color normColor;
    private float normWidth;

    private Color spezColor;
    private float spezWidth = 20;
    
    private bool active;
    private bool isLookedAt;
   

    private Selectable selected;
    private iInteraction interaction;

    private void Start()
    {
        selected = GetComponent<Selectable>();
        normColor = selected.OutlineColor;
        normWidth = selected.OutlineWidth;
        spezColor = new Color(normColor.r, normColor.g + 1, normColor.b);
        interaction = GetComponent<iInteraction>();
    }

    private void updateOutline()
    {
        if (isLookedAt || active)
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
            updateOutline();
        }
        base.Update();
    }

    public void OnLookAt(bool isLookedAt)
    {
        this.isLookedAt = isLookedAt;
        updateOutline();
    }

    public void OnPointerClick()
    {
        if (!active)
        {
            interaction.OnActivate();
            active = true;
            updateOutline();
        }

    }

}
