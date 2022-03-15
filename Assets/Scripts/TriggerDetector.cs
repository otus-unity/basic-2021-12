using System;
using UnityEngine;

public sealed class TriggerDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"Trigger enter {collider.gameObject.name}");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log($"Trigger exit {collider.gameObject.name}");
    }
}