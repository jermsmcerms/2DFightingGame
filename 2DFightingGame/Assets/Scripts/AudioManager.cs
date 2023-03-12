using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        private AudioSource m_audioSource;

        public List<AudioClip> BuildMatchEndClips(Dictionary<string, AudioClip> audioClips, List<Fighter> fighters, bool timeOverFlag, int currentRound) {
            List<AudioClip> m_matchEndClips = new();
            if (timeOverFlag) {
                m_matchEndClips.Add(audioClips["TIME_OVER"]);
                if (fighters[0].RoundsWon == MatchManager.ROUNDS_TO_WIN &&
                    fighters[1].RoundsWon == MatchManager.ROUNDS_TO_WIN) {
                    m_matchEndClips.Add(audioClips["DRAW_GAME"]);
                }
                else if (currentRound == MatchManager.MAX_ROUNDS &&
                    fighters[0].Health == fighters[1].Health &&
                    fighters[0].RoundsWon == fighters[1].RoundsWon) {
                    m_matchEndClips.Add(audioClips["DRAW_GAME"]);
                }
                else if (fighters[0].Health != fighters[1].Health) {
                    m_matchEndClips.Add(audioClips["YOU_WIN"]);
                }
            }
            else {
                if (fighters[0].Health == 0 && fighters[1].Health == 0) {
                    m_matchEndClips.Add(audioClips["DOUBLE_KO"]);
                    if (fighters[0].RoundsWon == MatchManager.ROUNDS_TO_WIN &&
                        fighters[1].RoundsWon == MatchManager.ROUNDS_TO_WIN) {
                        m_matchEndClips.Add(audioClips["DRAW_GAME"]);
                    }
                }
                else if (fighters[0].Health == fighters[0].MaxHealth ||
                    fighters[1].Health == fighters[1].MaxHealth) {
                    m_matchEndClips.Add(audioClips["KO"]);
                    m_matchEndClips.Add(audioClips["PERFECT"]);
                    m_matchEndClips.Add(audioClips["YOU_WIN"]);
                }
                else {
                    m_matchEndClips.Add(audioClips["KO"]);
                    m_matchEndClips.Add(audioClips["YOU_WIN"]);
                }
            }

            return m_matchEndClips;
        }

        public IEnumerator PlayAsync(AudioClip clip) {
            m_audioSource.clip = clip;
            m_audioSource.Play();
            yield return new WaitUntil(() => m_audioSource.isPlaying == false);
        }

        private void Awake() {
            m_audioSource = GetComponent<AudioSource>();
        }
    }
}
