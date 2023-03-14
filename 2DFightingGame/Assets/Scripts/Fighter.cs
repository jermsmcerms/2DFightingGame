using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDFG {
    public class Fighter : MonoBehaviour
    {
        public static event Action<Fighter> UpdateHealthEvent;
        
        public int PlayerNumber { get; set; }


        public int Health { get { return m_health; } set { m_health = value; } }
        [SerializeField]
        private int m_health;

        public int MaxHealth { get; set; }

        public int RoundsWon { get { return m_roundsWon; } set { m_roundsWon = value; } }
        private int m_roundsWon;

        public bool IsKnockedOut() => m_health < 0;

        public void UpdateHealth() {
            // Save this call for later when I implement
            // taking damgae from other players
            int value1 = Random.Range(0, 2);
            if (value1 == 0) {
                int value2 = Random.Range(0, 2);
                m_health -= value2;
                if (UpdateHealthEvent != null) {
                    UpdateHealthEvent(this);
                }
            }
        }

        private void Awake() {
            MaxHealth = Health;
        }
    }
}
