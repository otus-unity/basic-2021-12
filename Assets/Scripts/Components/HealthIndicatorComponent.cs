using UnityEngine;

namespace Components
{
    internal sealed class HealthIndicatorComponent: MonoBehaviour
    {
        private TextMesh textMesh;
        private HealthComponent health;
        private float displayedHealth;

        private void Start()
        {
            textMesh = GetComponent<TextMesh>();
            health = GetComponentInParent<HealthComponent>();
            displayedHealth = health.Health - 1.0f;
        }

        private void Update()
        {
            float value = health.Health;
            if (!Mathf.Approximately(displayedHealth, value))
            { // !=
                displayedHealth = value;
                textMesh.text = $"{value}";
            }
        }
    }
}
