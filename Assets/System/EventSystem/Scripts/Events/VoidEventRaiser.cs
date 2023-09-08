using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidEventRaiser : MonoBehaviour
{
   public VoidEvent voidEvent;

   public void Raise()
   {
        voidEvent.raiseEvent();
   }
}
