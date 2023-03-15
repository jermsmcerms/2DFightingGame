using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        private AudioSource m_audioSource;

        private List<AudioClip> m_introClips;

        public void BuildIntroClips(AnnouncerData announcerData) {
            m_introClips.Clear();

            int randomIndex = Random.Range(0, announcerData.matchIntroAudioClipSetA.Count);
            m_introClips.Add(announcerData.matchIntroAudioClipSetA[randomIndex]);

            randomIndex = Random.Range(0, announcerData.matchIntroAudioClipSetB.Count);
            m_introClips.Add(announcerData.matchIntroAudioClipSetB[randomIndex]);
        }

        public List<AudioClip> BuildMatchEndClips(Dictionary<string, AudioClip> audioClips, bool timeOverFlag, int currentRound) {
            List<AudioClip> m_matchEndClips = new();
            if (timeOverFlag) {
                m_matchEndClips.Add(audioClips["TIME_OVER"]);
                if (currentRound == MatchManager.MAX_ROUNDS) {
                    m_matchEndClips.Add(audioClips["DRAW_GAME"]);
                }
            }
            else {
                m_matchEndClips.Add(audioClips["KO"]);
                m_matchEndClips.Add(audioClips["YOU_WIN"]);
            }

            return m_matchEndClips;
        }

        public IEnumerator PlayAsync(AudioClip clip) {
            m_audioSource.clip = clip;
            m_audioSource.Play();
            yield return new WaitUntil(() => m_audioSource.isPlaying == false);
        }

        public IEnumerator PlayIntroClipsAsync() {
            foreach (AudioClip clip in m_introClips) {
                yield return PlayAsync(clip);
            }
        }

        private void Awake() {
            m_audioSource = GetComponent<AudioSource>();
            m_introClips = new();
        }
    }
}
