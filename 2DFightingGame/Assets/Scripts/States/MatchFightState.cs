using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    public class MatchFightState : AMatchState
    {
        public override void Update(MatchManager matchManager) {
            matchManager.UpdateFight();
        }
    }
}
