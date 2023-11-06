using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform target;
    public PathSO path;
    public TExperimentConfiguration experimentalConfig;

    public void TargetPlacement() 
    {
        float targetPos = experimentalConfig.GetCurrentTarget();
        target.position = path.GetPointInPath(targetPos);
    }

}
