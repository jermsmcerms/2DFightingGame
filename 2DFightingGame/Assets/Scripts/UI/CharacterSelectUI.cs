using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDFG {
    [RequireComponent(typeof(AudioSource))]
    public class CharacterSelectUI : MonoBehaviour
    {
        public int PlayerIndex { get { return m_playerIndex; } set { m_playerIndex = value; } }
        private int m_playerIndex;

        public Text TitleText { get { return m_titleText; } set { m_titleText = value; } }
        [SerializeField]
        private Text m_titleText;

        public GridLayoutGroup CharacterSelectGrid { get { return m_characterSelectGrid; } }
        [SerializeField]
        private GridLayoutGroup m_characterSelectGrid;

        public FighterDataContainer FighterData { get { return m_fighterData; } }
        [SerializeField]
        private FighterDataContainer m_fighterData;

        [SerializeField]
        private AudioClip m_selectClip;

        [SerializeField]
        private AudioClip m_submitClip;

        private AudioSource m_audioSource;

        public void OnSelect() {
            m_audioSource.clip = m_selectClip;
            m_audioSource.Play();
        }

        public void OnSubmit(int characterIndex) {
            StartCoroutine(HandleSubmitEvent(characterIndex));
        }

        private void Awake() {
            m_audioSource = GetComponent<AudioSource>();
        }

        private IEnumerator HandleSubmitEvent(int characterIndex) {
            m_audioSource.clip = m_submitClip;
            m_audioSource.Play();
            yield return new WaitUntil(() => m_audioSource.isPlaying == false);

            PlayerConfigurationManager.Instance.SetFighterData(m_playerIndex, m_fighterData.fighters[characterIndex]);
            PlayerConfigurationManager.Instance.ReadyPlayer(m_playerIndex);
        }
    }
}
