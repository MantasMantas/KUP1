using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathManager : MonoBehaviour
{
    public PathSO path;
    public Transform OriginPoint;
    public float lineWidth;
    public VoidEvent pathConfigured;

    private Transform StartArea;
    private LineRenderer lineRenderer;

    [Range(0f, 1f)]
    private float CurveValue;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ConfigurePath() 
    {
        LineVisible();
        GameObject copyOfOrigin = CopyOfComponenet.MakeTCopy(OriginPoint);
        path.InitializePath(copyOfOrigin.transform, lineRenderer);
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        pathConfigured.raiseEvent();
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
