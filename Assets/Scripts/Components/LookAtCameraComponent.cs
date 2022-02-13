using UnityEngine;

namespace Components
{
    internal sealed class LookAtCameraComponent : MonoBehaviour
    {
        Transform mainCameraTransform;

        private void Start()
        {
            mainCameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            transform.LookAt(mainCameraTransform);
        }
    }
}
