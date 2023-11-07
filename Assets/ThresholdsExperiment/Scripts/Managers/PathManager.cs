using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathManager : MonoBehaviour
{
    public PathSO path;
    public Transform OriginPoint;
    public float lineWidth;

    private Transform StartArea;
    private LineRenderer lineRenderer;

    [Range(0f, 1f)]
    private float CurveValue;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ConfigurePath();
    }

    public void ConfigurePath() 
    {
        LineVisible();
        GameObject copyOfOrigin = CopyOfComponenet.MakeTCopy(OriginPoint);
        path.InitializePath(copyOfOrigin.transform, lineRenderer);
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        
        //OriginPoint.position = path.GetPointInPath(0.5f);
    }

    public void LineVisible() 
    {
        lineRenderer.enabled = true;
    }

    public void LineInvisible()
    {
        lineRenderer.enabled = false;
    }

}
