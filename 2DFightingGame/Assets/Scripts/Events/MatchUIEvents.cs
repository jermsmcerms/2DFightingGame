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
        }

        private void OnDestroy() {
            MatchManager.ResetUI -= ResetUI;
            MatchManager.UpdateMatchTimer -= UpdateMatchTimer;
        }


        private void ResetUI() {
            m_matchUI.SetRoundStateText("");
        }

        private void UpdateMatchTimer(float time) {
            m_matchUI.UpdateMatchTimer(time);
        }
    }
}
