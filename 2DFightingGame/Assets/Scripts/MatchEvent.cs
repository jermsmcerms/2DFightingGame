using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDFG {
    public class MatchEvent : MonoBehaviour {
        [SerializeField]
        private MatchUI m_matchUI;

        private void Awake() {
            MatchManager.KnockoutEvent += HandleKnockoutEvent;
            MatchManager.InitializeUI += InitializeUI;
            MatchManager.TimeOverEvent += HandleTimeOverEvent;
            MatchManager.ResetUI += ResetUI;
            MatchManager.UpdateMatchTimer += UpdateMatchTimer;
            Fighter.UpdateHealthEvent += UpdateHealth;

        }

        private void OnDestroy() {
            MatchManager.KnockoutEvent -= HandleKnockoutEvent;
            MatchManager.InitializeUI -= InitializeUI;
            MatchManager.TimeOverEvent -= HandleTimeOverEvent;
            MatchManager.ResetUI -= ResetUI;
            MatchManager.UpdateMatchTimer -= UpdateMatchTimer;

            Fighter.UpdateHealthEvent -= UpdateHealth;

        }

        private void CheckForRoundsWon(List<Fighter> fighters, int currentRound) {
            fighters.ForEach(f => {
                if (f.RoundsWon == MatchManager.ROUNDS_TO_WIN) {
                    SceneManager.LoadScene((int)SceneIndex.REMATCH);
                }
            });

            if(currentRound == MatchManager.MAX_ROUNDS) {
                SceneManager.LoadScene((int)SceneIndex.REMATCH);
            }
        }

        private void HandleKnockoutEvent(List<Fighter> fighters, int currentRound) {
            if (fighters[0].IsKnockedOut()) {
                fighters[1].RoundsWon++;
                m_matchUI.UpdateRoundsWon(fighters[1].PlayerNumber, fighters[1].RoundsWon);
            }
            else if (fighters[1].IsKnockedOut()) {
                fighters[0].RoundsWon++;
                m_matchUI.UpdateRoundsWon(fighters[0].PlayerNumber, fighters[0].RoundsWon);
            }

            CheckForRoundsWon(fighters, currentRound);

            m_matchUI.SetRoundStateText("KO");
        }

        private void HandleTimeOverEvent(List<Fighter> fighters, int currentRound) {
            if (fighters[0].Health > fighters[1].Health) {
                fighters[0].RoundsWon++;
                m_matchUI.UpdateRoundsWon(fighters[0].PlayerNumber, fighters[0].RoundsWon);
            }
            else if (fighters[1].Health > fighters[0].Health) {
                fighters[1].RoundsWon++;
                m_matchUI.UpdateRoundsWon(fighters[1].PlayerNumber, fighters[1].RoundsWon);
            }
            CheckForRoundsWon(fighters, currentRound);

            m_matchUI.SetRoundStateText("Time Over");
        }

        private void InitializeUI(Fighter fighter) {
            m_matchUI.UpdateHealth(fighter.PlayerNumber, fighter.Health);
        }

        private void ResetUI() {
            m_matchUI.SetRoundStateText("");
        }

        private void UpdateHealth(int playerNumber, int health) {
            m_matchUI.UpdateHealth(playerNumber, health);
        }

        private void UpdateMatchTimer(float time) {
            m_matchUI.UpdateMatchTimer(time);
        }
    }
}
