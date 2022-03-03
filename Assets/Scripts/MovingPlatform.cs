using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed;

    private float current;
    private float dir;
    
    void Start()
    {
        current = 0.0f;
        dir = 1.0f;
    }
    
    void Update()
    {
        current += dir * speed * Time.deltaTime;
        if (current > 1.0f)
        {
            current = 1.0f;
            dir = -1.0f;
        } else if (current < 0.0f)
        {
            current = 0.0f;
            dir = 1.0f;
        }

        transform.position = Vector3.Lerp(point1.position, point2.position, current);
    }
}
