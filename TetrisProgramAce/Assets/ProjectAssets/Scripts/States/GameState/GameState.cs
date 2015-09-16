using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class GameState : AppState
    {
        private FiguresManager figuresManager;

        public override void Activate(IStateData data, bool resetState)
        {
            Application.LoadLevel("GameField");
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
        }


    }
}
