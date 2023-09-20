using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;

[CreateAssetMenu(fileName = "PathSO", menuName = "Scriptable Objects/Path/New Path SO")]
public class PathSO : ScriptableObject
{
    public GameObject BezierPoints;

    private VertexPath GeneratePath(GameObject points, Transform originPoint) 
    {
        Transform[] pointTransforms = points.GetComponentsInChildren<Transform>();
        pointTransforms = pointTransforms.Where((item, index) => index != 0).ToArray();

        BezierPath bezierPath = new BezierPath(pointTransforms, false, PathSpace.xyz);

        return new VertexPath(bezierPath, originPoint);
    }
}
