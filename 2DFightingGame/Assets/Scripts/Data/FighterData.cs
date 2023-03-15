using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    [CreateAssetMenu]
    public class FighterData : ScriptableObject
    {
        public int fighterId;
        public string fighterName;
        public int health;
        public BoxData boxData;

        public Box2D Box { get { return m_box; } }
        private Box2D m_box;

        public void InitBox() {
            m_box = new Box2D(boxData);
        }
    }
}
