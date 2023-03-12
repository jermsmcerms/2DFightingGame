using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace TDFG {
    [RequireComponent(typeof(MatchEvent))]
    [RequireComponent(typeof(AudioSource))]
    public class MatchManager : MonoBehaviour
    {
        /**
         * static events
         */
        public static event Action<Fighter> InitializeUI;
        public static event Action<List<Fighter>> TimeOverEvent;
        public static event Action<List<Fighter>> KnockoutEvent;
        public static event Action ResetUI;

        /**
         * public static fields
         */
        public static readonly int ROUNDS_TO_WIN = 2;

        /**
         * editor fields
         */
        [SerializeField]
        private List<PlayerController> m_players;

        [SerializeField]
        private List<AudioClip> m_narratorClips;

        [SerializeField]
        private TMP_Text m_matchTimeText;

        [SerializeField]
        private float m_matchTimeLength;

        [SerializeField]
        private float m_roundEndTimeLength;

        /**
         * private fields
         */
        private List<Fighter> m_fighters;
        private float m_matchTimer;
        private float m_roundEndTimer;
        private MatchState m_currentState;
        private AudioSource m_audioSource;
        private bool m_matchEndStarted;
        private bool m_timeOverFlag;

        /**
         * public interface
         */

        /**
         * unity api functions
         */
        void Awake() {
            m_fighters = new();
            
            m_roundEndTimer = m_roundEndTimeLength;
            m_matchTimer = m_matchTimeLength;
            m_audioSource = GetComponent<AudioSource>();
            m_matchEndStarted = false;
        }

        private void Start() {
            for (int i = 0; i < m_players.Count; i++) {
                m_players[i].Fighter.PlayerNumber = i;
                if (InitializeUI != null) {
                    InitializeUI(m_players[i].Fighter);
                }
                m_fighters.Add(m_players[i].Fighter);
            }

            m_currentState = MatchState.FIGHT;
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
                    if(!m_matchEndStarted) {
                        StartCoroutine(RunMatchEndEvents());
                    }
                    break;
                }
            }
        }

        /**
         * private functions
         */
        private void CheckForGameOver() {
            if(m_matchTimer < 0.0 && TimeOverEvent != null) {
                m_currentState = MatchState.END;
                m_timeOverFlag = true;
            }
            else {
                m_fighters.ForEach(f => {
                    if (f.IsKnockedOut()) {
                        m_currentState = MatchState.END;
                    }
                });
            }
        }

        private IEnumerator RunMatchEndEvents() {
            m_matchEndStarted = true;

            List<AudioClip> m_matchEndClips = new();
            if(m_timeOverFlag) {
                m_matchEndClips.Add(m_narratorClips[4]); // time over
                if (m_fighters[0].RoundsWon == ROUNDS_TO_WIN &&
                    m_fighters[1].RoundsWon == ROUNDS_TO_WIN) {
                    m_matchEndClips.Add(m_narratorClips[1]); // draw game
                }
            }
            else {
                if (m_fighters[0].Health == 0 && m_fighters[1].Health == 0) {
                    m_matchEndClips.Add(m_narratorClips[0]); // double ko
                    if (m_fighters[0].RoundsWon == ROUNDS_TO_WIN &&
                        m_fighters[1].RoundsWon == ROUNDS_TO_WIN) {
                        m_matchEndClips.Add(m_narratorClips[1]); // draw game
                    }
                }
                else if (m_fighters[0].Health == m_fighters[0].MaxHealth ||
                    m_fighters[1].Health == m_fighters[1].MaxHealth) {
                    m_matchEndClips.Add(m_narratorClips[2]); // ko
                    m_matchEndClips.Add(m_narratorClips[3]); // perfect
                }
                else {
                    m_matchEndClips.Add(m_narratorClips[2]); // ko
                    m_matchEndClips.Add(m_narratorClips[5]); // you win
                }
            }

            for (int i = 0; i < m_matchEndClips.Count; i++) {
                yield return StartCoroutine(PlayClip(m_matchEndClips[i]));
            }

            if(m_timeOverFlag && TimeOverEvent != null) {
                TimeOverEvent(m_fighters);
                m_matchTimer = m_matchTimeLength;
                m_fighters.ForEach(f => f.Health = f.MaxHealth);
                m_currentState = MatchState.FIGHT;
                if (ResetUI != null) {
                    ResetUI();
                }
                m_matchEndStarted = false;
                m_timeOverFlag = false;
            }
            else if (KnockoutEvent != null) {
                KnockoutEvent(m_fighters);
                // If we get here it means there is another round to play...
                m_matchTimer = m_matchTimeLength;
                m_fighters.ForEach(f => f.Health = f.MaxHealth);
                m_currentState = MatchState.FIGHT;
                if (ResetUI != null) {
                    ResetUI();
                }
                m_matchEndStarted = false;
                m_timeOverFlag = false;
            }
        }

        private IEnumerator PlayClip(AudioClip clip) {
            m_audioSource.clip = clip;
            m_audioSource.Play();
            yield return new WaitUntil(() => m_audioSource.isPlaying == false);
        }

        private void UpdateMatchTimer() {
            m_matchTimer -= Time.deltaTime;
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
    } // end of MatchManager class

    public enum MatchState {
        START,
        FIGHT,
        END
    }
}
