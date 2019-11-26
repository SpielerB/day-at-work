using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : Outline
{
    private Outline outline;
    private Color normColor = new Color(48, 148, 255);
    private Color spezColor = new Color(155, 222, 255); //+75
    private int normWidth = 15;
    private int spezWidth = 20;

    private void Start()
    {
        outline = this.GetComponent<Outline>();
    }

    public void OnLookAt(bool isLookedAt)
    {
        if (isLookedAt)
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

    public void OnPointerClick()
    {

    }
}
