using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class GameState : AppState
    {
        public override void Activate(IStateData data, bool resetState)
        {
            Application.LoadLevel("GameField");
        }
    }
}
