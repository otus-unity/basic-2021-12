using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTexture : MonoBehaviour
{
    public float changeX;
    public float changeY;
    
    void Update()
    {
        float xOffset = Time.time * changeX;
        float yOffset = Time.time * changeY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(xOffset, yOffset);
    }
}
