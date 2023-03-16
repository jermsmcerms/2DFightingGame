using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    [CreateAssetMenu]
    public class ActionData : ScriptableObject
    {
        public int actionId;
        public SpriteAnimationDataContainer animationData;
    }
}
