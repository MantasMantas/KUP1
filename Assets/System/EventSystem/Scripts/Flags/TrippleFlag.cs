using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New tripple flag", menuName = "Scriptable Objects/Flag/New tripple flag")]
public class TrippleFlag : ScriptableObject 
{
    private bool enabled1 = false;
    private bool enabled2 = false;
    private bool enabled3 = false;

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

    public void EnableFlag3()
    {
        enabled3 = true;
        CheckFlags();
    }

    private void DisableFlags()
    {
        enabled1 = false;
        enabled2 = false;
        enabled3 = false;
    }

    private void CheckFlags()
    {
        if (enabled1 && enabled2 && enabled3)
        {
            triggerEvent.raiseEvent();
            DisableFlags();
        }
    }
}
