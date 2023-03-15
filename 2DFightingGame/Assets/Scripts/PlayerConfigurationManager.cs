using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace TDFG {
    [RequireComponent(typeof(PlayerInputManager))]
    public class PlayerConfigurationManager : MonoBehaviour
    {
        public static PlayerConfigurationManager Instance { get; private set; }

        public List<PlayerConfiguration> PlayerConfigurations { get { return m_playerConfigs; } } 
        private List<PlayerConfiguration> m_playerConfigs;

        [SerializeField]
        private CharacterSelectUI m_characterSelectUI;


        private PlayerInputManager m_inputManager;

        public void HandlePlayerJoin(PlayerInput input) {
            m_characterSelectUI.TitleText.text = "choose your fighter!";
            if(!m_playerConfigs.Any(p => p.PlayerIndex == input.playerIndex)) {
                m_playerConfigs.Add(new PlayerConfiguration(input));
                m_characterSelectUI.PlayerIndex = input.playerIndex;
            }
        }

        public void SetFighterData(int playerIndex, FighterData fighterData) {
            m_playerConfigs[playerIndex].FighterData = fighterData;
        }

        public void ReadyPlayer(int playerIndex) {
            m_playerConfigs[playerIndex].IsReady = true;
            if(m_playerConfigs.Count == m_inputManager.maxPlayerCount &&
                m_playerConfigs.All(p => p.IsReady == true)) {
                Debug.Log("Fire event to end this scene and then load the next scene when finished");
                SceneManager.LoadScene((int)SceneIndex.MATCH);
            }
        }

        private void Awake() {
            if(Instance != null) {
                Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class");
                return;
            }

            Instance = this;
            DontDestroyOnLoad(Instance);
            m_playerConfigs = new();

            m_inputManager = GetComponent<PlayerInputManager>();
        }
    }

    public class PlayerConfiguration {
        public PlayerInput Input { get; private set; }
        public int PlayerIndex { get; private set; }
        public bool IsReady { get; set; }
        public FighterData FighterData { get; set; }

        public PlayerConfiguration(PlayerInput pi) {
            PlayerIndex = pi.playerIndex;
            Input = pi;
        }
    }
}
