using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TDFG {
    public class RematchUI : MonoBehaviour
    {
        [SerializeField]
        private Button m_rematchButton;

        [SerializeField]
        private Button m_mainMenuButton;

        public void OnMainMenu() {
            SceneManager.LoadScene((int)SceneIndex.MAIN);
        }

        public void OnRematch() {
            SceneManager.LoadScene((int)SceneIndex.MATCH);
        }
    }
}
