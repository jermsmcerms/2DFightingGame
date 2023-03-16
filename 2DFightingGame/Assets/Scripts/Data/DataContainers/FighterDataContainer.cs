using System.Collections.Generic;
using UnityEngine;

namespace TDFG {
    [CreateAssetMenu]
    public class FighterDataContainer : ScriptableObject
    {
        public List<FighterData> fighters;
    }
}
