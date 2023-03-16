using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDFG
{
    public class PlayerMatchUI : MonoBehaviour
    {
        [SerializeField]
        private List<Text> m_roundsWonText;

        [SerializeField]
        private Text m_name;

        [SerializeField]
        private Image m_health;

        [SerializeField]
        private Text m_healthText;

        public void SetName(string name) {
            m_name.text = name;
        }

        public void UpdateHealth(float healthPercent) {
            m_health.transform.localScale = new Vector3(healthPercent, 1, 1);
        }

        public void UpdateHealthText(int health) {
            m_healthText.text = health.ToString();
        }

        public void UpdateRoundWonText(int index, string text) {
            m_roundsWonText[index].text = text;
        }
    }
}
