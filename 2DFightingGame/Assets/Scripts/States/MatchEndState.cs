using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    public class MatchEndState : AMatchState
    {
        public override void Update(MatchManager matchManager) {
            matchManager.EndMatch();
        }
    }
}
