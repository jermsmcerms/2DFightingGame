using UnityEngine;

namespace TDFG {
    [CreateAssetMenu]
    public class FighterData : ScriptableObject
    {
        public int fighterId;
        public string fighterName;
        public int maxHealth;
        public float forwardWalkSpeed;
        public float backwardWalkSpeed;
        public ActionDataContainer actionData;

        public int Health { get; set; }
        
        public void InitData() {
            Health = maxHealth;
        }
    }
}
