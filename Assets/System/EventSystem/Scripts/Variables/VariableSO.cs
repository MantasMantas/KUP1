using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSO : ScriptableObject
{
    public VoidEvent awakeEvent;

   private void OnEnable()
   {
       if(awakeEvent != null)
       {
           awakeEvent.OnEventRaised += awake;
       }
   }

   private void OnDisable()
   {
       if(awakeEvent != null)
       {
           awakeEvent.OnEventRaised -= awake;
       }
   }

   public virtual void awake()
   {
    // base inplemented in individual object
   }
}
