using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierGenerator : MonoBehaviour
{
    public Transform[] bezierPoints;

    public Transform testObject, testOrigin;
    public float speed;
    float dstTraveled;

    VertexPath vertexPath;
    void Start()
    {
        vertexPath = GeneratePath(bezierPoints, false);
    }

    // Update is called once per frame
    void Update()
    {
        dstTraveled += speed * Time.deltaTime;
        testObject.position = vertexPath.GetPointAtDistance(dstTraveled, EndOfPathInstruction.Loop);
        testObject.rotation = vertexPath.GetRotationAtDistance(dstTraveled, EndOfPathInstruction.Loop);
    }

    private VertexPath GeneratePath(Transform[] points, bool closedPath) 
    {
        BezierPath bezierPath = new BezierPath(bezierPoints, closedPath, PathSpace.xyz);

        return new VertexPath(bezierPath, testOrigin);
    }
}
