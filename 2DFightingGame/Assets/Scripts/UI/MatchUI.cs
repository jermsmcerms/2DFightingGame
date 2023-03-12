using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TDFG
{
    public class MatchUI : MonoBehaviour
    {

        [SerializeField]
        private TMP_Text m_roundStateText;

        [SerializeField]
        private List<TMP_Text> m_playerHealthList;

        [SerializeField]
        private List<TMP_Text> m_playerRoundsWonList;

        [SerializeField]
        private TMP_Text m_matchTimer;

        public string SetRoundStateText(string text) => m_roundStateText.text = text;

        public void UpdateHealth(int index, int health) {
            if(index >= 0 && index < m_playerHealthList.Count) {
                m_playerHealthList[index].text = health.ToString();
            }
        }
        
        public void UpdateMatchTimer(float time) {
            m_matchTimer.text = time.ToString("F0");
        }

        public void UpdateRoundsWon(int index, int roundsWon) {
            if(index >= 0 && index < m_playerRoundsWonList.Count) {
                m_playerRoundsWonList[index].text = roundsWon.ToString();
            }
        }
    }
}
