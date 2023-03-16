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
            MatchManager.InitializePlayerUI += InitializePlayerUI;
            MatchManager.ResetUI += ResetUI;
            MatchManager.UpdateMatchTimer += UpdateMatchTimer;
        }

        private void OnDestroy() {
            MatchManager.InitializePlayerUI -= InitializePlayerUI;
            MatchManager.ResetUI -= ResetUI;
            MatchManager.UpdateMatchTimer -= UpdateMatchTimer;
        }

        private void InitializePlayerUI(int index, FighterData data) {
            m_matchUI.PlayerUiList[index].SetName(data.fighterName);
            m_matchUI.PlayerUiList[index].UpdateHealth(data.Health / (float)data.maxHealth);
            m_matchUI.PlayerUiList[index].UpdateHealthText(data.Health);
        }

        private void ResetUI() {
            m_matchUI.SetRoundStateText("");
        }

        private void UpdateMatchTimer(float time) {
            m_matchUI.UpdateMatchTimer(time);
        }
    }
}
