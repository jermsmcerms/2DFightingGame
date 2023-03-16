using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    [CreateAssetMenu]
    public class SpriteAnimationData : ScriptableObject
    {
        public List<AnimationFrameData> frames;
    }

    [System.Serializable]
    public class AnimationFrameData {
        public Sprite sprite;
        public float frameLength;
    }
}
