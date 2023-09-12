using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one float argument
/// </summary>

[CreateAssetMenu(fileName = "New Vector3 Event", menuName = "EventSystem/Events/Vector3 Event")]
public class Vector3Event : ScriptableObject
{
    public UnityAction<Vector3> OnEventRaised;

    public void raiseEvent(Vector3 value)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(value);
        }
    }
}
