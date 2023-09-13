using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;

public class ControllerMove : MonoBehaviour
{
    public enum SelectedAxis {x, y, z };
    public SelectedAxis selectedAxis;

    public Transform controller, controllerAnchor;
    public GameObject bezierPoints;
    public Transform startArea, cursor;

    public float ThumbstickSpeed = 1f;
    //public char selectedAxis;

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
        OffsetCalculation(inputValue.y * ThumbstickSpeed * Time.deltaTime);
    }

    [SerializeField]
    public void ThumbstickInputHorizontal(Vector2 inputValue)
    {
        OffsetCalculation(inputValue.x * ThumbstickSpeed * Time.deltaTime);
    }

    [SerializeField]
    public void ControllerInput(Vector3 inputValue)
    {
        OffsetCalculationControllerMove(inputValue);
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
        moveValue += inputValue;
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

    private void OffsetCalculationControllerMove(Vector3 inputValue) 
    {
        switch (selectedAxis) 
        {
            case SelectedAxis.x:
                moveValue += inputValue.x - (startArea.position.x / 3.5f);
                break;
            case SelectedAxis.y:
                moveValue += inputValue.y - (startArea.position.y / 3.5f);
                break;
            case SelectedAxis.z:
                moveValue += inputValue.z - (startArea.position.y / 3.5f);
                break;
        }

        offsetPos = vertexPath.GetPointAtDistance(moveValue, EndOfPathInstruction.Stop);
        offsetRot = vertexPath.GetRotationAtDistance(moveValue, EndOfPathInstruction.Stop);
    }

}
