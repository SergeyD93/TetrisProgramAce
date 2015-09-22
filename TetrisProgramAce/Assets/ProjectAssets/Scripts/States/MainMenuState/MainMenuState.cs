using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class MainMenuState : AppState
    {
        public override void Initialize()
        {
            mId = EAppStateId.MainMenu;
        }

        public override void Activate(IStateData data, bool resetState)
        {
            Application.LoadLevel("MainMenu");
        }
    }
}