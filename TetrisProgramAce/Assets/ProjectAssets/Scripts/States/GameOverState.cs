using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class GameOverState : AppState
    {
        GameObject mGUICanvas;

        public override void Initialize()
        {
            mId = EAppStateId.GameOver;
        }

        public override void Activate(IStateData data, bool resetState)
        {
            mGUICanvas = GameObject.Instantiate(Resources.Load("GUI/GameOver/GameOver") as GameObject);
        }

        public override void Deactivate()
        {
            GameObject.Destroy(mGUICanvas);
        }
    }
}