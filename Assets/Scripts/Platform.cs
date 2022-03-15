using UnityEngine;

public sealed class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform point1;

    [SerializeField]
    private Transform point2;

    [Space]
    [SerializeField]
    private float speed = 5.0f;

    private Transform currentPoint;

    private void Start()
    {
        this.currentPoint = this.point1;
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    private void Move()
    {
        var myPosition = this.transform.position;
        var targetPosition = this.currentPoint.position;
        
        var distanceVector = targetPosition - myPosition;
        var distance = distanceVector.magnitude;
        this.TryChangePoint(distance);
        
        var direction = distanceVector.normalized;
        var velocity = direction * (this.speed * Time.fixedDeltaTime);
        this.transform.position += velocity;
    }

    private void TryChangePoint(float distance)
    {
        if (distance <= 0.1f)
        {
            if (this.currentPoint == this.point1)
            {
                this.currentPoint = this.point2;
            }
            else
            {
                this.currentPoint = this.point1;
            }
        }
    }
}