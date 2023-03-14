using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDFG {
    [RequireComponent(typeof(AudioManager))]
    [RequireComponent(typeof(MatchEvent))]
    [RequireComponent (typeof(MatchUIEvents))]
    [RequireComponent(typeof(AudioSource))]
    public class MatchManager : MonoBehaviour
    {
        // Match events
        public static event Action<List<Fighter>, int> TimeOverEvent;
        public static event Action<List<Fighter>, int> KnockoutEvent;

        // Match UI events
        public static event Action<Fighter> InitializeUI;
        public static event Action ResetUI;
        public static event Action<float> UpdateMatchTimer;

        public static readonly int ROUNDS_TO_WIN = 2;
        public static readonly int MAX_ROUNDS = 3;

        [SerializeField]
        private List<PlayerController> m_players;

        [SerializeField]
        private float m_matchTimeLength;

        [SerializeField]
        private AnnouncerData m_announcerData;
        
        private float m_matchTimer;
        private MatchState m_currentState;
        private bool m_matchEndStarted;
        private bool m_matchIntroStarted;
        private bool m_timeOverFlag;
        private int m_currentRound;

        // Private components
        private List<Fighter> m_fighters;
        private AudioManager m_audioManager;

        void Awake() {
            m_fighters = new();
            
            m_matchTimer = m_matchTimeLength;
            m_audioManager = GetComponent<AudioManager>();
            m_matchEndStarted = false;
            m_currentRound = 1;
            m_announcerData.InitializeData();
        }

        private void Start() {
            for (int i = 0; i < m_players.Count; i++) {
                m_players[i].Fighter.PlayerNumber = i;
                if (InitializeUI != null) {
                    InitializeUI(m_players[i].Fighter);
                }
                m_fighters.Add(m_players[i].Fighter);
            }

            m_currentState = MatchState.START;
        }

        void Update() {
            switch (m_currentState) {
                case MatchState.START: {
                    if (!m_matchIntroStarted) {
                        StartCoroutine(RunMatchStartEvents());
                    }
                    break;
                }
                case MatchState.FIGHT: {
                    m_fighters.ForEach(fighter => fighter.UpdateHealth());
                    m_matchTimer -= Time.deltaTime;
                    if(UpdateMatchTimer != null) {
                        UpdateMatchTimer(m_matchTimer);
                    }
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
            List<AudioClip> m_matchEndClips = m_audioManager.BuildMatchEndClips(m_announcerData.MatchEndAudio, m_fighters, m_timeOverFlag, m_currentRound);

            for (int i = 0; i < m_matchEndClips.Count; i++) {
                yield return StartCoroutine(m_audioManager.PlayAsync(m_matchEndClips[i]));
            }

            HandleMatchEndEvents();
            ResetMatch();
        }

        private void ResetMatch() {
            m_currentRound++;
            m_matchTimer = m_matchTimeLength;
            m_fighters.ForEach(f => f.Health = f.MaxHealth);
            m_currentState = MatchState.START;
            if (ResetUI != null) {
                ResetUI();
            }
            m_matchEndStarted = false;
            m_matchIntroStarted = false;
            m_timeOverFlag = false;
        }

        private void HandleMatchEndEvents() {
            if (m_timeOverFlag && TimeOverEvent != null) {
                TimeOverEvent(m_fighters, m_currentRound);
            }

            else if (KnockoutEvent != null) {
                KnockoutEvent(m_fighters, m_currentRound);
            }
        }

        private IEnumerator RunMatchStartEvents() {
            m_matchIntroStarted = true;
            if (m_currentRound == MAX_ROUNDS) {
                yield return m_audioManager.PlayAsync(m_announcerData.MatchEndAudio["FINAL_ROUND"]);
            }
            else {
                List<AudioClip> introClips = new();
                int randomIndex = Random.Range(0, m_announcerData.matchIntroAudioClipSetA.Count);
                introClips.Add(m_announcerData.matchIntroAudioClipSetA[randomIndex]);
                
                randomIndex = Random.Range(0, m_announcerData.matchIntroAudioClipSetB.Count);
                introClips.Add(m_announcerData.matchIntroAudioClipSetB[randomIndex]);

                foreach (AudioClip clip in introClips) {
                    yield return m_audioManager.PlayAsync(clip);
                }
            }
            m_currentState = MatchState.FIGHT;
        }
    } // end of MatchManager class

    public enum MatchState {
        START,
        FIGHT,
        END
    }
}
