using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform posSocket, screen;
    private bool followStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceenFollowStart();
    }

    public void EnableFollow() 
    {
        followStart = true;
    }

    public void DisableFollow()
    {
        followStart = false;
    }

    private void SceenFollowStart() 
    {
        if (!followStart) { return; }
        screen.position = posSocket.position;
    }
}
