using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatVariable : VariableSO
{
    private float value;

    public void Set(float value) { this.value = value; }
    public float Get(){ return value;}
}
