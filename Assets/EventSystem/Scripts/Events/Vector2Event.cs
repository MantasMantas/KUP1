using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one float argument
/// </summary>

[CreateAssetMenu(fileName = "New Vector2 Event", menuName = "EventSystem/Events/Vector2 Event")]
public class Vector2Event : ScriptableObject
{
    public UnityAction<Vector2> OnEventRaised;

    public void raiseEvent(Vector2 value)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(value);
        }
    }
}
