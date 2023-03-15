using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG {
    [RequireComponent(typeof(AudioManager))]
    [RequireComponent(typeof(MatchUIEvents))]
    [RequireComponent(typeof(AudioSource))]
    public class MatchManager : MonoBehaviour
    {
        // Match events

        // Match UI events
        public static event Action ResetUI;
        public static event Action<float> UpdateMatchTimer;

        public static readonly int ROUNDS_TO_WIN = 2;
        public static readonly int MAX_ROUNDS = 3;

        [SerializeField]
        private float m_matchTimeLength;

        [SerializeField]
        private AnnouncerData m_announcerData;
        
        private float m_matchTimer;
        private bool m_matchEndStarted;
        private bool m_matchIntroStarted;
        private bool m_timeOverFlag;
        private int m_currentRound;

        // Private components
        private AudioManager m_audioManager;
        private AMatchState m_matchState;

        private List<FighterData> m_fighterData;

        public void EndMatch() {
            if (!m_matchEndStarted) {
                StartCoroutine(RunMatchEndEvents());
            }
        }

        public void StartMatch() {
            if (!m_matchIntroStarted) {
                StartCoroutine(RunMatchStartEvents());
            }
        }

        public void UpdateFight() {
            m_matchTimer -= Time.deltaTime;
            UpdateMatchTimer?.Invoke(m_matchTimer);
            CheckForGameOver();
        }

        private void Awake() {           
            m_matchTimer = m_matchTimeLength;
            m_audioManager = GetComponent<AudioManager>();
            m_matchEndStarted = false;
            m_currentRound = 1;
            m_announcerData.InitializeData();

            m_matchState = new MatchStartState();

            m_fighterData = new();

            PlayerConfigurationManager.Instance.PlayerConfigurations.ForEach(pi => { 
                Debug.Log(pi.FighterData.fighterName);
                pi.FighterData.InitBox();
                m_fighterData.Add(pi.FighterData);
            });
        }

        private void OnDrawGizmos() {
            m_fighterData?.ForEach(f => f.Box.DrawBox());
        }

        void Update() {
            m_matchState.Update(this);
        }

        private void CheckForGameOver() {
            if(m_matchTimer < 0.0) {
                m_matchState = m_matchState.ChangeState(MatchState.END);
                m_timeOverFlag = true;
            }
        }

        private IEnumerator RunMatchEndEvents() {
            m_matchEndStarted = true;
            List<AudioClip> m_matchEndClips = 
                m_audioManager.BuildMatchEndClips(m_announcerData.MatchEndAudio, m_timeOverFlag, m_currentRound);

            for (int i = 0; i < m_matchEndClips.Count; i++) {
                yield return StartCoroutine(m_audioManager.PlayAsync(m_matchEndClips[i]));
            }

            ResetMatch();
        }

        private void ResetMatch() {
            m_currentRound++;
            m_matchTimer = m_matchTimeLength;
            m_matchState = m_matchState.ChangeState(MatchState.START);

            ResetUI?.Invoke();
            m_matchEndStarted = false;
            m_matchIntroStarted = false;
            m_timeOverFlag = false;
        }

        private IEnumerator RunMatchStartEvents() {
            m_matchIntroStarted = true;
            if (m_currentRound == MAX_ROUNDS) {
                yield return m_audioManager.PlayAsync(m_announcerData.MatchEndAudio["FINAL_ROUND"]);
            }
            else {
                m_audioManager.BuildIntroClips(m_announcerData);
                yield return m_audioManager.PlayIntroClipsAsync();
            }
            m_matchState = m_matchState.ChangeState(MatchState.FIGHT);

        }
    } // end of MatchManager class
}
