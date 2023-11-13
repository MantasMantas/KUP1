using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New double flag", menuName = "Scriptable Objects/Flag/New double flag")]
public class DoubleFlag : ScriptableObject
{
    private bool enabled1 = false;
    private bool enabled2 = false;

    public VoidEvent triggerEvent;

    public void EnableFlag1()
    {
        enabled1 = true;
        CheckFlags();
    }

    public void EnableFlag2()
    {
        enabled2 = true;
        CheckFlags();
    }

    private void DisableFlags()
    {
        enabled1 = false;
        enabled2 = false;
    }

    private void CheckFlags() 
    {
        if (enabled1 && enabled2) 
        {
            triggerEvent.raiseEvent();
            DisableFlags();
        }
    }
}
