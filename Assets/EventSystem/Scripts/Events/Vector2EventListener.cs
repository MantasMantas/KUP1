using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>

[System.Serializable]

public class Vector2EventLs : UnityEvent<Vector2>
{

}

/// <summary>
/// A flexible handler for Vector2 events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class Vector2EventListener : MonoBehaviour
{
    [Tooltip("Event to register")]
    public Vector2Event vector2Event;


    [Tooltip("Response when the event is raised")]
    public Vector2EventLs OnEventRaised;

    private void OnEnable()
    {
        if (vector2Event != null)
        {
            vector2Event.OnEventRaised += respond;
        }
    }

    private void OnDisable()
    {
        if (vector2Event != null)
        {
            vector2Event.OnEventRaised -= respond;
        }
    }

    private void respond(Vector2 value)
    {
        OnEventRaised.Invoke(value);
    }
}
