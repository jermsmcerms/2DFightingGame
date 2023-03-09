using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TDFG
{
    [RequireComponent(typeof(Fighter))]
    public class PlayerController : MonoBehaviour
    {
        public Fighter Fighter { get { return m_fighter; } }
        [SerializeField]
        private Fighter m_fighter;

        [SerializeField]
        private float m_bufferWindow; 

        private InputType[] QCRight = { InputType.DOWN, InputType.DOWN_RIGHT, InputType.RIGHT };
        private InputType[] QCLeft = { InputType.DOWN, InputType.DOWN_LEFT, InputType.LEFT };

        private PlayerControls m_playerControls;
        private float m_inputTimer;
        private float m_lastInputTime;
        private int m_inputCounter1;
        private int m_inputCounter2;

        void Awake() {
            m_playerControls = new();
        }

        private void FixedUpdate() {
            Vector2 movement = m_playerControls.MatchControls.Movement.ReadValue<Vector2>();
            InputType currentInput = InputType.NEUTRAL;
            if (movement.x > 0.0f) {
                currentInput |= InputType.RIGHT;
            }
            else if (movement.x < 0.0f) {
                currentInput |= InputType.LEFT;
            }

            if (movement.y > 0.0f) {
                currentInput |= InputType.UP;
            }
            else if (movement.y < 0.0f) {
                currentInput |= InputType.DOWN;
            }

            if (m_inputCounter1 == 0 || m_inputTimer - m_lastInputTime < m_bufferWindow) {
                if (currentInput == QCRight[m_inputCounter1]) {
                    m_inputCounter1++;
                    m_lastInputTime = m_inputTimer;
                    if (m_inputCounter1 == QCRight.Length) {
                        Debug.Log("Quarter circle right input found");
                        m_inputCounter1 = 0;
                    }
                }

            }
            if(m_inputCounter2 == 0 || m_inputTimer - m_lastInputTime < m_bufferWindow) { 
                if (currentInput == QCLeft[m_inputCounter2]) {
                    m_inputCounter2++;
                    m_lastInputTime = m_inputTimer;
                    if (m_inputCounter2 == QCLeft.Length) {
                        Debug.Log("Quarter circle left input found");
                        m_inputCounter2 = 0;
                    }
                }
            }
            if (m_inputTimer - m_lastInputTime > m_bufferWindow) {
                m_inputCounter1 = 0;
                m_inputCounter2 = 0;
            }
            m_inputTimer += Time.fixedDeltaTime;
        }

        private void OnDisable() {
            m_playerControls.Disable();
        }

        private void OnEnable() {
            m_playerControls.Enable();
        }
    }
}
