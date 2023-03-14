using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDFG {
    public class MatchEvent : MonoBehaviour {
        public static event Action<Fighter, string> UpdatePlayerUI;

        private void Awake() {
            MatchManager.KnockoutEvent += HandleKnockoutEvent;
            MatchManager.TimeOverEvent += HandleTimeOverEvent;

        }

        private void OnDestroy() {
            MatchManager.KnockoutEvent -= HandleKnockoutEvent;
            MatchManager.TimeOverEvent -= HandleTimeOverEvent;

        }

        private void CheckForRoundsWon(List<Fighter> fighters, int currentRound) {
            fighters.ForEach(f => {
                if (f.RoundsWon == MatchManager.ROUNDS_TO_WIN) {
                    SceneManager.LoadScene((int)SceneIndex.REMATCH);
                }
            });

            if(currentRound == MatchManager.MAX_ROUNDS) {
                SceneManager.LoadScene((int) SceneIndex.REMATCH);
            }
        }

        private void HandleKnockoutEvent(List<Fighter> fighters, int currentRound) {
            if (fighters[0].IsKnockedOut()) {
                fighters[1].RoundsWon++;
                if (UpdatePlayerUI != null) {
                    string winText = "W";
                    if (fighters[1].Health == fighters[1].MaxHealth) {
                        winText = "P";
                    }
                    UpdatePlayerUI(fighters[1], winText);
                }
            }
            else if (fighters[1].IsKnockedOut()) {
                fighters[0].RoundsWon++;
                if (UpdatePlayerUI != null) {
                    string winText = "W";
                    if (fighters[0].Health == fighters[0].MaxHealth) {
                        winText = "P";
                    }
                    UpdatePlayerUI(fighters[0], winText);
                }
            }

            CheckForRoundsWon(fighters, currentRound);
        }

        private void HandleTimeOverEvent(List<Fighter> fighters, int currentRound) {
            if (fighters[0].Health > fighters[1].Health) {
                fighters[0].RoundsWon++;
                if (UpdatePlayerUI != null) {
                    string winText = "T";
                    if (fighters[0].Health == fighters[0].MaxHealth) {
                        winText = "P";
                    }
                    UpdatePlayerUI(fighters[0], winText);
                }
            }
            else if (fighters[1].Health > fighters[0].Health) {
                fighters[1].RoundsWon++;
                if (UpdatePlayerUI != null) {
                    string winText = "T";
                    if (fighters[1].Health == fighters[1].MaxHealth) {
                        winText = "P";
                    }
                    UpdatePlayerUI(fighters[1], winText);
                }
            }
            CheckForRoundsWon(fighters, currentRound);
        }
    }
}
