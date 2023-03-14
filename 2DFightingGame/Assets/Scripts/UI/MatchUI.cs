using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDFG
{
    public class MatchUI : MonoBehaviour
    {

        [SerializeField]
        private Text m_roundStateText;

        [SerializeField]
        private List<PlayerMatchUI> m_playerMatchUI;

        [SerializeField]
        private Text m_matchTimer;

        public string SetRoundStateText(string text) => m_roundStateText.text = text;

        public void UpdateHealth(Fighter fighter) {
            float healthPercent = fighter.Health / (float)fighter.MaxHealth;
            m_playerMatchUI[fighter.PlayerNumber].UpdateHealth(healthPercent);
        }

        public void UpdateMatchTimer(float time) {
            m_matchTimer.text = time.ToString("F0");
        }

        public void UpdateRoundsWon(Fighter fighter, string text) {
            m_playerMatchUI[fighter.PlayerNumber].UpdateRoundWonText(fighter.RoundsWon - 1, text);
        }
    }
}
