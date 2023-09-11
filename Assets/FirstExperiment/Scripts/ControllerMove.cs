using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ControllerMove : MonoBehaviour
{


    public Transform controller, controllerAnchor;
    public Transform[] bezierPoints;
    public Transform startArea;

    public float ThumbstickSpeed = 1f;

    private Vector3 offsetPos;
    private Quaternion offsetRot;
    private VertexPath vertexPath;

    float moveValue;

    public Transform testObject;


    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        vertexPath = GeneratePath(bezierPoints, startArea);
        DrawBezierCurve(vertexPath);
    }

    // Update is called once per frame
    void Update()
    {
        //controller.position = controllerAnchor.position + offsetPos;
        //controller.rotation = controllerAnchor.rotation + offsetRot;
        testObject.position = offsetPos;
    }


    public void TriggerPress() 
    {
        // here goes the trigger press logic
        Debug.Log("Trigger was pressed!!!");
    }

    // reset the position to the default
    public void ThumstickPress() 
    {
        offsetPos = Vector3.zero;
    }

    [SerializeField]
    public void ThumbstickInputReach(Vector2 inputValue)
    {
        offsetPos += new Vector3(0, 0, inputValue.y) * Time.deltaTime * ThumbstickSpeed;
    }

    [SerializeField]
    public void ThumbstickInputVectical(Vector2 inputValue)
    {
        //y
        moveValue += (inputValue.y * -1) * Time.deltaTime * ThumbstickSpeed;
        if(moveValue > 1) 
        {
            moveValue = 1;
        }
        if(moveValue < -1) 
        {
            moveValue = -1;
        }

        Debug.Log("Move value: " + moveValue);
        offsetPos = vertexPath.GetPointAtDistance(moveValue, EndOfPathInstruction.Stop);
        

    }

    [SerializeField]
    public void ThumbstickInputHorizontal(Vector2 inputValue)
    {
        //x
    }

    private VertexPath GeneratePath(Transform[] points, Transform originPoint) 
    {
        BezierPath bezierPath = new BezierPath(points, false, PathSpace.xyz);

        return new VertexPath(bezierPath, originPoint);
    }

    private void DrawBezierCurve(VertexPath vertexPath) 
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = vertexPath.NumPoints;

        for(int i = 0; i < vertexPath.NumPoints; i++) 
        {
            lineRenderer.SetPosition(i, vertexPath.GetPoint(i));
        }
        
    }

}
