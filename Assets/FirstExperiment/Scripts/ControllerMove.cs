using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{


    public Transform controller, controllerAnchor;

    public float ThumbstickSpeed = 1f, radius = 1f, ElevationOffset = 0f;

    private Vector3 offset;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.position = controllerAnchor.position + offset;
    }


    public void TriggerPress() 
    {
        // here goes the trigger press logic
        Debug.Log("Trigger was pressed!!!");
    }

    // reset the position to the default
    public void ThumstickPress() 
    {
        offset = Vector3.zero;
    }

    [SerializeField]
    public void ThumbstickInputReach(Vector2 inputValue)
    {
        offset += new Vector3(0, 0, inputValue.y) * Time.deltaTime * ThumbstickSpeed;
    }

    [SerializeField]
    public void ThumbstickInputVectical(Vector2 inputValue) 
    {

    }

    [SerializeField]
    public void ThumbstickInputHorizontal(Vector2 inputValue)
    {
        angle = inputValue.x;

        offset = new Vector3(Mathf.Sin(angle), ElevationOffset, Mathf.Cos(angle));
    }

}
