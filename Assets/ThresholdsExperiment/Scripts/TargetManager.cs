using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform target;
    public PathSO path;
    public TargetPositions targetPositions;
    // Start is called before the first frame update


    private void Start()
    {
        TargetDemo();   
    }


    public void TargetPlacement() 
    {
        target.position = path.GetPointInPath(targetPositions.GetRandomTargetPosition());
    }

    public void TargetDemo() 
    {
        target.position = path.GetPointInPath(0.8f);
    }
}
