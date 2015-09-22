using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class MainMenu : ScriptableObject
    {
        public void StartGame()
        {
            AppRoot.Instance.SetState(EAppStateId.Game, true);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
