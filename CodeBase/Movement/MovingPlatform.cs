using UnityEngine;

namespace CodeBase.Movement
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard,
        Impossible
    }
    
    public class MovingPlatform : MonoBehaviour
    {
        public float moveSpeed;
        public float stoppingDistance;
        public Transform targetPoint;

        private float _speedMultiplier = 1f;

        private void Update()
        {
            MovePlatform();
        }

        private void MovePlatform()
        {
            float effectiveSpeed = moveSpeed * _speedMultiplier;
            Vector3 direction = (targetPoint.position - transform.position).normalized;
            Vector3 newPosition = transform.position + direction * effectiveSpeed * Time.deltaTime;

            transform.position = newPosition;

            float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
            if (distanceToTarget < stoppingDistance)
            {
                StopMoving();
            }
        }

        private void StopMoving()
        {
            _speedMultiplier = 0f;
        }

        public void UpdateSpeed(float newSpeed)
        {
            _speedMultiplier = newSpeed / moveSpeed;
            MovePlatform();
        }
    }
}
