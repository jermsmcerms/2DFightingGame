using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    public class TestMatch : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerController> m_players;

        private List<Fighter> m_fighters;

        private void Awake() {
            m_fighters = new();
            for (int i = 0; i < m_players.Count; i++) {
                m_players[i].Fighter.PlayerNumber = i;
                m_fighters.Add(m_players[i].Fighter);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
