using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform target;
    public PathSO path;
    public TargetPositions targetPositions;
    // Start is called before the first frame update

    public void TargetPlacement() 
    {
        target.position = path.GetPointInPath(targetPositions.GetRandomTargetPosition());
    }
}
