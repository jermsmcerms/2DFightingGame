using UnityEngine;
using UnityEngine.InputSystem;

namespace TDFG {
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float m_forwardWalkSpeed;
        
        [SerializeField]
        private float m_backwardWalkSpeed;

        [SerializeField]
        private Vector3 m_jumpForce;

        [SerializeField]
        private Rigidbody m_rigidBody;

        private PlayerControls m_playerControls;

        private bool IsGrounded() => m_rigidBody.velocity.y <= 0.0f;

        private void Awake() {
            m_playerControls = new PlayerControls();
            m_playerControls.MatchControls.Movement.performed += OnMovement;
            m_playerControls.MatchControls.Movement.canceled += OnMovement;
        }

        private void OnDisable() {
            m_playerControls.Disable();
        }

        private void OnEnable() {
            m_playerControls.Enable();
        }

        private void Update() {
            Vector2 direction = m_playerControls.MatchControls.Movement.ReadValue<Vector2>();
            if(direction.x > 0.0f) {
                m_rigidBody.velocity = new Vector3(m_forwardWalkSpeed, m_rigidBody.velocity.y, m_rigidBody.velocity.z);
            }
            else if (direction.x < 0.0f) {
                m_rigidBody.velocity = new Vector3(-m_backwardWalkSpeed, m_rigidBody.velocity.y, m_rigidBody.velocity.z);
            }
            else {
                m_rigidBody.velocity = new Vector3(0.0f, m_rigidBody.velocity.y, m_rigidBody.velocity.z);
            }
        }

        private void OnMovement(InputAction.CallbackContext context) {
            if (context.performed && IsGrounded()) {
                Vector2 direction = m_playerControls.MatchControls.Movement.ReadValue<Vector2>();
                if (direction.y > 0.0f) {
                    m_rigidBody.AddForce(m_jumpForce);
                }
            }
        }
    }
}
