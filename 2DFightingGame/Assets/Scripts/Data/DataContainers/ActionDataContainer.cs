using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    [CreateAssetMenu]
    public class ActionDataContainer : ScriptableObject
    {
        public List<ActionData> actions;
    }
}
