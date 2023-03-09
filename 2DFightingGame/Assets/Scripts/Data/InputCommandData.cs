using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDFG
{
    public class InputCommandData : ScriptableObject
    {
        public List<InputType> inputs;
    }

    public enum InputType {
        NEUTRAL     = 0,
        UP          = 1,
        DOWN        = 2,
        LEFT        = 4,
        RIGHT       = 8,
        UP_LEFT     = UP | LEFT,    //  5
        UP_RIGHT    = UP | RIGHT,   //  9
        DOWN_LEFT   = DOWN | LEFT,  //  8
        DOWN_RIGHT  = DOWN | RIGHT, // 10
    }
}
