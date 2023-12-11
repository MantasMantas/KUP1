using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pacer : MonoBehaviour
{
    public PathSO path;
    public TExperimentConfiguration experimentalConfig;
    public float speed;

    private bool isPacer;
    private float targetPos, currentPos, speedInternal;
    private Renderer renderer;
    private delegate bool ComparisonOperator(float a, float b);
    private ComparisonOperator comparison;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PacerUpdates();
    }

    private void PacerUpdates() 
    {
        if(!isPacer) { return; }

        if(comparison(currentPos,targetPos)) 
        {
            DisablePacer();
            return;
        }

        currentPos += speedInternal;

        transform.position = path.GetPointInPath(currentPos);

    }

    public void EnablePacer()
    {
        isPacer = true;
        currentPos = 0.5f;
        transform.position = path.GetPointInPath(currentPos);
        targetPos = experimentalConfig.GetCurrentTarget();
        renderer.enabled = true;

        if(currentPos > targetPos) 
        {
            speedInternal = speed * -1;
            comparison = (a, b) => a <= b;
        }
        else 
        {
            speedInternal = speed;
            comparison = (a, b) => a >= b;
        }

    }

    private void DisablePacer() 
    {
        isPacer = false;
        renderer.enabled = false;
    }
}
