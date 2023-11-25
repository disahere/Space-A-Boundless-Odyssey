using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [FormerlySerializedAs("Panel")] public GameObject panel;
        private Rigidbody _rigidbody;
        public float moveSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var keyboardMovement = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;

            foreach (Touch touch in Input.touches)
            {
                // ReSharper disable once PossibleLossOfFraction
                if (touch.position.x < Screen.width / 2)
                {
                    _rigidbody.velocity = new Vector3(-moveSpeed, _rigidbody.velocity.y, 0f);
                }
                else
                {
                    _rigidbody.velocity = new Vector3(moveSpeed, _rigidbody.velocity.y, 0f);
                }
            }

            if (Input.touchCount == 0)
            {
                _rigidbody.velocity = new Vector3(keyboardMovement * moveSpeed, _rigidbody.velocity.y, 0f);
            }

            if (IsInsideLimitTrigger())
            {
                _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
            }
        }

        private bool IsInsideLimitTrigger()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.2f);

            return colliders.Length > 0 && colliders[0].CompareTag("LimitTrigger");
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