using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDFG {
    public class Fighter : MonoBehaviour
    {
        public static event Action<int, int> UpdateHealthEvent;
        
        public int PlayerNumber { get; set; }


        public int Health { get { return m_health; } set { m_health = value; } }
        [SerializeField]
        private int m_health;

        public int MaxHealth { get; set; }

        public int RoundsWon { get { return m_roundsWon; } set { m_roundsWon = value; } }
        private int m_roundsWon;

        public bool IsKnockedOut() => m_health < 0;

        public void UpdateHealth() {
            int randomUpdate = Random.Range(0, 2);
            if(randomUpdate == 1) {
                int randomDamage = Random.Range(0, 2);
                Health -= randomDamage;
                if(UpdateHealthEvent != null) {
                    UpdateHealthEvent(PlayerNumber, Health);
                }
            }
        }
    }
}
