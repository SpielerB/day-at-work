using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerWindow : MonoBehaviour
{

    protected virtual void Start()
    {
        
    }


    public virtual bool CanClose()
    {
        return true;
    }

    public void Close()
    {
        if (CanClose())
        {
            gameObject.SetActive(false);
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

}
