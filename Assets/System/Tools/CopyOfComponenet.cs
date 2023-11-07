using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CopyOfComponenet
{
    public static GameObject MakeTCopy(Transform original) 
    {
        GameObject copy = new GameObject("Copy of " + original.name);

        copy.transform.position = original.position;
        copy.transform.rotation = original.rotation;
        copy.transform.localScale = Vector3.one;

        return copy;
    }
}
