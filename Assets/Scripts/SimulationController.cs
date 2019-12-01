﻿using System;
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
        now = DateTime.Now.Date.AddHours(startHour ?? 7).AddMinutes(startMinute ?? 50);
    }

    public DateTime GetTime()
    {
        return now;
    }

    public string GetTimeString()
    {
        return now.ToString("HH:mm");
    }

    public string GetDateString()
    {
        return now.ToString("dd.MM.yyyy");
    }

    public void AdvanceTime(uint hour, uint minute)
    {
        now = now.AddHours(hour).AddMinutes(minute);
    }

    public void SetTime(uint hour, uint minute)
    {
        now = now.Date.AddHours(hour).AddMinutes(minute);

    }

    public void EndSimulation()
    {
        Application.Quit();
    }

}
