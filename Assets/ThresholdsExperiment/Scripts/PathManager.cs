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

    [Range(0f, 1.25f)]
    private float CurveValue;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        path.InitializePath(OriginPoint, lineRenderer);
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        StartArea = OriginPoint.GetChild(0).GetComponent<Transform>();
        StartArea.position = path.GetPointInPath(0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
