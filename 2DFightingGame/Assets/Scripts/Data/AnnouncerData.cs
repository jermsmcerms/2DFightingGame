using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    [CreateAssetMenu]
    public class AnnouncerData : ScriptableObject
    {
        public List<AudioClip> matchIntroAudioClipSetA;
        public List<AudioClip> matchIntroAudioClipSetB;
        public List<AudioClip> matchEndAudioClipSet;

        public Dictionary<string, AudioClip> MatchEndAudio { get { return m_matchEndAudio; } }
        private Dictionary<string, AudioClip> m_matchEndAudio;

        public static readonly string[] MATCH_END_CLIP_NAMES = {
            "DOUBLE_KO", "DRAW_GAME", "FINAL_ROUND",
            "KO", "PERFECT", "TIME_OVER", "YOU_WIN"
        };

        public void InitializeData() {
            m_matchEndAudio = new();
            for (int i = 0; i < matchEndAudioClipSet.Count; i++) {
                m_matchEndAudio.Add(MATCH_END_CLIP_NAMES[i], matchEndAudioClipSet[i]);
            }
        }
    }
}
