using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerWindow : MonoBehaviour
{

    public event EventHandler OnWindowOpened;
    public event EventHandler OnWindowClosed;
    private void CloseWindow() => OnWindowClosed?.Invoke(this, EventArgs.Empty);
    private void OpenWindow() => OnWindowOpened?.Invoke(this, EventArgs.Empty);

    public virtual bool CanClose() => true;

    public void Close()
    {
        if (!CanClose()) return;
        gameObject.SetActive(false);
        CloseWindow();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        OpenWindow();
    }

}
