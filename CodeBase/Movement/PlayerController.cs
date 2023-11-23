using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [FormerlySerializedAs("Panel")] public GameObject panel;
        private Rigidbody _rb;
        public float moveSpeed;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);

            _rb.velocity = !IsInsideLimitTrigger() ? new Vector3(moveDirection.x * moveSpeed, _rb.velocity.y, 0f) : new Vector3(0f, _rb.velocity.y, 0f);
        }

        private bool IsInsideLimitTrigger()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.2f);

            return colliders.Any(collider => collider.CompareTag("LimitTrigger"));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Block")) return;
            
            Destroy(gameObject);
            ShowDeathPanel();
        }

        private void ShowDeathPanel()
        {
            panel.SetActive(true);
        }
    }
}
