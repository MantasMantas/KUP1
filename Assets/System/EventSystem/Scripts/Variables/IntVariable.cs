using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Int Variable", menuName = "Scriptable Objects/Variables/New Int Variable")]
public class IntVariable : VariableSO
{
    private int value;

    public void Set(int value) { this.value = value; }
    public int Get() { return value; }
}
