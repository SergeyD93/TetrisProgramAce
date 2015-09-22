using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class PauseMenu : ScriptableObject
    {
        public void Resume()
        {
            AppRoot.Instance.Unpause();
        }

        public void Restart()
        {
            AppRoot.Instance.Restart();
        }

        public void MainMenu()
        {
            AppRoot.Instance.SetState(EAppStateId.MainMenu);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
