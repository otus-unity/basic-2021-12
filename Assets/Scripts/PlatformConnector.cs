using System;
using UnityEngine;

namespace DefaultNamespace
{
    public sealed class PlatformConnector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }
}