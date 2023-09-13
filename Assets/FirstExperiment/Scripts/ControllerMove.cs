using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;

public class ControllerMove : MonoBehaviour
{


    public Transform controller, controllerAnchor;
    public GameObject bezierPoints;
    public Transform startArea, cursor;

    public float ThumbstickSpeed = 1f;

    private Vector3 offsetPos;
    private Quaternion offsetRot;
    private VertexPath vertexPath;

    private float moveValue;


    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        vertexPath = GeneratePath(bezierPoints, startArea);
        DrawBezierCurve(vertexPath);
        moveValue = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        cursor.position = offsetPos;
        cursor.rotation = offsetRot;
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
        OffsetCalculation(inputValue.y);
    }

    [SerializeField]
    public void ThumbstickInputHorizontal(Vector2 inputValue)
    {
        OffsetCalculation(inputValue.x);
    }

    [SerializeField]
    public void ControllerInput(Vector3 inputValue)
    {
        moveValue = inputValue.y - (startArea.position.y/3.5f);

        if (moveValue > 1.25)
        {
            moveValue = 1.25f;
        }
        if (moveValue < 0)
        {
            moveValue = 0;
        }

        offsetPos = vertexPath.GetPointAtDistance(moveValue, EndOfPathInstruction.Stop);
        offsetRot = vertexPath.GetRotationAtDistance(moveValue, EndOfPathInstruction.Stop);
    }

    private VertexPath GeneratePath(GameObject points, Transform originPoint) 
    {
        Transform[] pointTransforms = points.GetComponentsInChildren<Transform>();
        pointTransforms = pointTransforms.Where((item, index) => index != 0).ToArray();

        BezierPath bezierPath = new BezierPath(pointTransforms, false, PathSpace.xyz);

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

    private void OffsetCalculation(float inputValue) 
    {
        moveValue += inputValue * Time.deltaTime * ThumbstickSpeed;
        if (moveValue > 1.25)
        {
            moveValue = 1.25f;
        }
        if (moveValue < 0)
        {
            moveValue = 0;
        }

        Debug.Log(moveValue);
        offsetPos = vertexPath.GetPointAtDistance(moveValue, EndOfPathInstruction.Stop);
        offsetRot = vertexPath.GetRotationAtDistance(moveValue, EndOfPathInstruction.Stop);
    }

}
