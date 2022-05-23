using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Fork fork;

    private float offset;

    void Start()
    {
        if(Fork.isAlive)
        {
            offset = transform.position.y - fork.transform.position.y;
        }
    }

    void Update()
    {
        if(Fork.isAlive)
        {
            Vector3 currentPos = transform.position;
            currentPos.y = fork.transform.position.y + offset;
            transform.position = currentPos;
        }
    }
}
