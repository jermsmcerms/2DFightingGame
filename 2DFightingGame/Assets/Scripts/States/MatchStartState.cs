using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    public class MatchStartState : AMatchState
    {
        public override void Update(MatchManager matchManager) {
            matchManager.StartMatch();
        }
    }
}
