using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    public class MatchUIEvents : MonoBehaviour
    {
        [SerializeField]
        private MatchUI m_matchUI;

        private void Awake() {
            MatchManager.ResetUI += ResetUI;
            MatchManager.UpdateMatchTimer += UpdateMatchTimer;
            MatchEvent.UpdatePlayerUI += UpdatePlayerUI;
            Fighter.UpdateHealthEvent += UpdateHealth;
        }

        private void OnDestroy() {
            MatchManager.ResetUI -= ResetUI;
            MatchManager.UpdateMatchTimer -= UpdateMatchTimer;
            MatchManager.InitializeUI -= InitializeUI;
            MatchEvent.UpdatePlayerUI -= UpdatePlayerUI;
            Fighter.UpdateHealthEvent -= UpdateHealth;
        }

        private void InitializeUI(Fighter fighter) {
            m_matchUI.UpdateHealth(fighter);
        }

        private void ResetUI() {
            m_matchUI.SetRoundStateText("");
        }

        private void UpdateHealth(Fighter fighter) {
            m_matchUI.UpdateHealth(fighter);
        }

        private void UpdateMatchTimer(float time) {
            m_matchUI.UpdateMatchTimer(time);
        }

        private void UpdatePlayerUI(Fighter fighter, string text) {
            m_matchUI.UpdateRoundsWon(fighter, text);
        }
    }
}
