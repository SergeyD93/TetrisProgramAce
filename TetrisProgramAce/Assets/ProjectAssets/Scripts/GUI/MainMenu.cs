using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class MainMenu : ScriptableObject
    {
        static GameObject mAboutWindow;
        static GameObject mRulesWindow;

        public void StartGame()
        {
            AppRoot.Instance.SetState(EAppStateId.Game, true);
        }

        public void Exit()
        {
            Application.Quit();
            GameObject.Find("StartButton").SetActive(false);
        }

        public void OpenRules()
        {
            if (mRulesWindow == null)
            {
                mRulesWindow = GameObject.Instantiate(Resources.Load("GUI/MainMenu/Rules") as GameObject);
            }
            else 
            {
                mRulesWindow.SetActive(true);
            }
        }
        public void CloseRules()
        {
            if (mRulesWindow != null)
            {
                mRulesWindow.SetActive(false);
            }
        }
        
        public void OpenAbout()
        {
            if (mAboutWindow == null)
            {
                mAboutWindow = GameObject.Instantiate(Resources.Load("GUI/MainMenu/About") as GameObject);
            }
            else
            {
                mAboutWindow.SetActive(true);
            }
        }

        public void CloseAbout()
        {
            if (mAboutWindow != null)
            {
                mAboutWindow.SetActive(false);
            }
        }

        public void SetLevel0()
        {
            UserData.Instance.SetLevel(0);
        }

        public void SetLevel1()
        {
            UserData.Instance.SetLevel(1);
        }

        public void SetLevel2()
        {
            UserData.Instance.SetLevel(2);
        }
    }
}
