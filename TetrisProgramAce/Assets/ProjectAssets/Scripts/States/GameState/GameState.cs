using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class GameState : AppState
    {
        private FiguresManager figuresManager;

        public override void Initialize()
        {
            mId = EAppStateId.Game;
        }

        public override void Activate(IStateData data, bool resetState)
        {
            if (resetState == false)
            {
                Time.timeScale = 1;
            }
            else
            {
                UserData.Instance.ResetScore();
                Time.timeScale = 1;
                Application.LoadLevel("GameField");
            }
        }

        public override void OnLevelWasLoaded(int level) 
        {
            figuresManager = new FiguresManager();
        }

        public override void Update()
        {
            if (figuresManager != null)
            {
                figuresManager.Update();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AppRoot.Instance.Pause();
            }
        }

        public override void Deactivate()
        {

        }
    }
}
