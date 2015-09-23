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
            if (mGUICanvas == null)
            {
                mGUICanvas = GameObject.Instantiate(Resources.Load("GUI/PauseMenu/PauseMenu") as GameObject);
            }
            else
            {
                mGUICanvas.SetActive(true);
            }
        }

        public override void Deactivate()
        {
            mGUICanvas.SetActive(false);
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
