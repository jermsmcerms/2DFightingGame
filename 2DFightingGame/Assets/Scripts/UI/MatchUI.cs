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

        public void SetRoundStateText(string text) => m_roundStateText.text = text;

        public void UpdateMatchTimer(float time) {
            m_matchTimer.text = time.ToString("F0");
        }
    }
}
