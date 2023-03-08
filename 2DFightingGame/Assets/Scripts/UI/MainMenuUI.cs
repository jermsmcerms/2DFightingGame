using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TDFG {
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField]
        private Button m_startButton;

        [SerializeField]
        private Button m_exitButton;

        public void OnExit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
        }

        public void OnStart() {
            SceneManager.LoadScene((int)SceneIndex.MATCH);
        }
    }
}
