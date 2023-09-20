using UnityEngine;
using PathCreation;
using System.Linq;

[CreateAssetMenu(fileName = "PathSO", menuName = "Scriptable Objects/Path/New Path SO")]
public class PathSO : ScriptableObject
{
    public GameObject BezierPoints;

    private VertexPath vertexPath;

    public void InitializePath(Transform originPoint) 
    {
        GeneratePath(BezierPoints, originPoint);
    }

    public Vector3 GetPointInPath(float point) 
    {
        return vertexPath.GetPointAtDistance(point, EndOfPathInstruction.Stop);
    }

    public Quaternion GetRotationInPath(float point) 
    {
        return vertexPath.GetRotationAtDistance(point, EndOfPathInstruction.Stop);
    }

    private VertexPath GeneratePath(GameObject points, Transform originPoint) 
    {
        Transform[] pointTransforms = points.GetComponentsInChildren<Transform>();
        pointTransforms = pointTransforms.Where((item, index) => index != 0).ToArray();

        BezierPath bezierPath = new BezierPath(pointTransforms, false, PathSpace.xyz);

        return new VertexPath(bezierPath, originPoint);
    }

    private void DrawPath(VertexPath vertexPath, LineRenderer lineRenderer)
    {
        lineRenderer.positionCount = vertexPath.NumPoints;

        for (int i = 0; i < vertexPath.NumPoints; i++)
        {
            lineRenderer.SetPosition(i, vertexPath.GetPoint(i));
        }

    }
}
