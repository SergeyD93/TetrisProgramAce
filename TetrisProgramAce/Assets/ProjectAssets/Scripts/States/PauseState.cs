using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class PauseState : AppState
    {
        GameObject mGUICanvas;

        public override void Initialize()
        {
            mId = EAppStateId.Pause;
        }

        public override void Activate(IStateData data, bool resetState)
        {
            Time.timeScale = 0;

            mGUICanvas = GameObject.Instantiate(Resources.Load("GUI/PauseMenu/PauseMenu") as GameObject);
        }

        public override void Deactivate()
        {
            GameObject.Destroy(mGUICanvas);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AppRoot.Instance.Unpause();
            }
        }

    }
}
