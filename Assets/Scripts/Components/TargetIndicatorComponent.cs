using System;
using UnityEngine;

namespace Components
{
    public sealed class TargetIndicatorComponent : MonoBehaviour
    {
        [SerializeField] private GameObject targetIndicator;

        private void Start()
        {
            DisableTargetIndicator();
        }

        public void EnableTargetIndicator()
        {
            targetIndicator.SetActive(true);
        }
        
        public void DisableTargetIndicator()
        {
            targetIndicator.SetActive(false);
        }
    }
}
