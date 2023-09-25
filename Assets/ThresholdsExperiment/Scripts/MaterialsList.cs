using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Materials List", menuName = "Scriptable Objects/Materials/Materials list")]
public class MaterialsList : ScriptableObject
{
    public Material[] materials;

    public Material GetDefault() 
    {
        return materials[0];
    }

    public Material GetFocusOn() 
    {
        return materials[1];
    }

    public Material GetTouching() 
    {
        return materials[2];
    }

}
