using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{

    public uint? startHour;
    public uint? startMinute;

    private DateTime now;

    private void Start()
    {
        now = DateTime.Now.Date.AddHours(startHour ?? 9).AddMinutes(startMinute ?? 0);
    }

    public string GetTimeString()
    {
        return now.ToString("HH:mm");
    }

    public string GetDateString()
    {
        return now.ToString("dd.MM.yyyy");
    }

    public void Advance()
    {
        now = now.AddMinutes(1);
    }

}
