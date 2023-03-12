using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TDFG {
    [RequireComponent(typeof(AudioSource))]
    public class MenuUI : MonoBehaviour
    {
        [SerializeField]
        private Button m_startButton;

        [SerializeField]
        private Button m_exitButton;

        [SerializeField]
        private Button m_rematchButton;

        [SerializeField]
        private Button m_mainMenuButton;

        [SerializeField]
        private AudioClip m_navigateClip;

        [SerializeField]
        private AudioClip m_selectClip;

        private AudioSource m_audioSource;

        public void OnExit() {
            StartCoroutine(LoadScene(SceneIndex.QUIT));
        }
        public void OnMainMenu() {
            StartCoroutine(LoadScene(SceneIndex.MAIN));
        }

        public void OnRematch() {
            StartCoroutine(LoadScene(SceneIndex.MATCH));
        }

        public void OnSelect() {
            m_audioSource.clip = m_navigateClip;
            m_audioSource.Play();
        }

        public void OnStart() {
            StartCoroutine(LoadScene(SceneIndex.MATCH));
        }

        private void Awake() {
            m_audioSource = GetComponent<AudioSource>();
        }

        private IEnumerator LoadScene(SceneIndex index) {
            m_audioSource.clip = m_selectClip;
            m_audioSource.Play();

            yield return new WaitUntil(() => m_audioSource.isPlaying == false);
            
            if(index == SceneIndex.QUIT) {
                QuitApplication();
            }
            else {
                SceneManager.LoadScene((int)index);
            }
        }

        private void QuitApplication() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
