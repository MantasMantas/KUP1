using UnityEngine;
using PathCreation;
using System.Linq;

[CreateAssetMenu(fileName = "PathSO", menuName = "Scriptable Objects/Path/New Path SO")]
public class PathSO : ScriptableObject
{
    public GameObject BezierPoints;
    public bool DisplayPath;

    private VertexPath vertexPath;

    public void InitializePath(Transform originPoint, LineRenderer lineRenderer) 
    {
       vertexPath = GeneratePath(BezierPoints, originPoint, lineRenderer);
    }

    public Vector3 GetPointInPath(float point) 
    {
        return vertexPath.GetPointAtDistance(point, EndOfPathInstruction.Stop);
    }

    public Quaternion GetRotationInPath(float point) 
    {
        return vertexPath.GetRotationAtDistance(point, EndOfPathInstruction.Stop);
    }

    public Vector3 GetClosestPointToPath(Vector3 point) 
    {
        return vertexPath.GetClosestPointOnPath(point);
    }

    public Quaternion GetClosestRotationToPath(Vector3 point) 
    {
        return vertexPath.GetRotationAtDistance(vertexPath.GetClosestTimeOnPath(point));
    }

    public float GetClosestCurveValue(Vector3 point) 
    {
        return vertexPath.GetClosestTimeOnPath(point);
    }

    private VertexPath GeneratePath(GameObject points, Transform originPoint, LineRenderer lineRenderer) 
    {
        Transform[] pointTransforms = points.GetComponentsInChildren<Transform>();
        pointTransforms = pointTransforms.Where((item, index) => index != 0).ToArray();

        BezierPath bezierPath = new BezierPath(pointTransforms, false, PathSpace.xyz);

        VertexPath vertexPath = new VertexPath(bezierPath, originPoint);

        if (DisplayPath) 
        {
            DrawPath(vertexPath, lineRenderer);
        }

        return vertexPath;
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
