using System;
using UnityEngine;

public sealed class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var objectName = collision.gameObject.name;
        Debug.Log($"Collision enter with: {objectName}");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var objectName = collision.gameObject.name;
        Debug.Log($"Collision stay with: {objectName}");   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var objectName = collision.gameObject.name;
        Debug.Log($"Collision exit with: {objectName}");
    }
}