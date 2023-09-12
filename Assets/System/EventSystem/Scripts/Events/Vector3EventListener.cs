using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>

[System.Serializable]

public class Vector3EventLs : UnityEvent<Vector3>
{

}

/// <summary>
/// A flexible handler for Vector2 events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class Vector3EventListener : MonoBehaviour
{
    [Tooltip("Event to register")]
    public Vector3Event vector3Event;


    [Tooltip("Response when the event is raised")]
    public Vector3EventLs OnEventRaised;

    private void OnEnable()
    {
        if (vector3Event != null)
        {
            vector3Event.OnEventRaised += respond;
        }
    }

    private void OnDisable()
    {
        if (vector3Event != null)
        {
            vector3Event.OnEventRaised -= respond;
        }
    }

    private void respond(Vector3 value)
    {
        OnEventRaised.Invoke(value);
    }
}