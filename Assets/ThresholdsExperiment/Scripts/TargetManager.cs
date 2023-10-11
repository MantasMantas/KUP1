using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform target;
    public PathSO path;
    // Start is called before the first frame update


    private void Start()
    {
  
    }


    public void TargetPlacement() 
    {
        target.position = path.GetPointInPath(Random.Range(0f,1f));
    }

}
