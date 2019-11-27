using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerWindow : MonoBehaviour
{

    public virtual bool CanClose()
    {
        return true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

}
