using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class MainMenuState : AppState
    {
        public override void Activate(IStateData data, bool resetState)
        {
            Application.LoadLevel("MainMenu");
        }

        public void StartGame()
        {
            AppRoot.Instance.SetState(EAppStateId.Game);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}