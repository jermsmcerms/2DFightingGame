using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TDFG {
    [RequireComponent(typeof(MatchEvent))]
    public class MatchManager : MonoBehaviour
    {
        public static event Action<Fighter> InitializeUI;
        public static event Action<List<Fighter>> TimeOverEvent;
        public static event Action<List<Fighter>> KnockoutEvent;
        public static event Action ResetUI;

        public static readonly int ROUNDS_TO_WIN = 2;

        public List<Fighter> Fighters { get { return m_fighters; } }
        [SerializeField]
        private List<Fighter> m_fighters;

        [SerializeField]
        private TMP_Text m_matchTimeText;

        [SerializeField]
        private float m_matchTimeLength;

        [SerializeField]
        private float m_roundEndTimeLength;

        private float m_matchTimer;
        private float m_roundEndTimer;
        private MatchState m_currentState;

        // Start is called before the first frame update
        void Awake() {
            for (int i = 0; i < m_fighters.Count; i++) {
                m_fighters[i].MaxHealth = m_fighters[i].Health;
                m_fighters[i].PlayerNumber = i;
                if(InitializeUI != null) {
                    InitializeUI(m_fighters[i]);
                }
            }

            m_currentState = MatchState.FIGHT;
            m_roundEndTimer = m_roundEndTimeLength;
            m_matchTimer = m_matchTimeLength;
        }

        // Update is called once per frame
        void Update() {
            switch (m_currentState) {
                case MatchState.FIGHT: {
                    m_fighters.ForEach(fighter => fighter.UpdateHealth());
                    UpdateMatchTimer();
                    CheckForGameOver();
                    break;
                }
                case MatchState.END: {
                    UpdateRoundEndTimer();
                    break;
                }
            }
        }

        private void CheckForGameOver() {
            if(m_matchTimeLength < 0.0 && TimeOverEvent != null) {
                TimeOverEvent(m_fighters);
                m_currentState = MatchState.END;
            }
            else {
                m_fighters.ForEach(f => {
                    if (f.IsKnockedOut() && KnockoutEvent != null) {
                        KnockoutEvent(m_fighters);
                        m_currentState = MatchState.END;
                    }
                });
            }
        }

        private void UpdateMatchTimer() {
            m_matchTimer -= Time.deltaTime;
            if (m_matchTimer < 0.0f) {
                m_currentState = MatchState.END;   
            }
            m_matchTimeText.text = m_matchTimer.ToString("F0");
        }

        private void UpdateRoundEndTimer() {
            m_roundEndTimer -= Time.deltaTime;
            if(m_roundEndTimer < 0.0) {
                m_roundEndTimer = m_roundEndTimeLength;
                m_matchTimer = m_matchTimeLength;
                m_fighters.ForEach(f => f.Health = f.MaxHealth);
                m_currentState = MatchState.FIGHT;
                if(ResetUI != null) {
                    ResetUI();
                }
            }
        }
    }

    public enum MatchState {
        START,
        FIGHT,
        END
    }
}