using UnityEngine;

namespace CodeBase.Movement
{
    public class MovingPlatform : MonoBehaviour
    {
        public float moveSpeed;
        public float stoppingDistance ;
        public Transform targetPoint;

        private void Update()
        {
            MovePlatform();
        }

        private void MovePlatform()
        {
            Vector3 direction = (targetPoint.position - transform.position).normalized;
            Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;

            transform.position = newPosition;

            float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
            if (distanceToTarget < stoppingDistance)
            {
                StopMoving();
            }
        }

        private void StopMoving()
        {
            moveSpeed = 0f;
        }
    }
}
