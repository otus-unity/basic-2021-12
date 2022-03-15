using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePhysics : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        print("Update " + Time.deltaTime);
    }

    private void FixedUpdate()
    {
        print("FixedUpdate" + Time.deltaTime);
    }
}
