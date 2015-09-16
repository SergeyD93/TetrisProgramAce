using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class UserData
    {
        private static UserData mInstance;
        public static UserData Instance 
        {
            get 
            {
                if (mInstance == null)
                {
                    mInstance = new UserData();
                }
                return mInstance;
            }
        }

        public int mLevel;
        public int mScore;
        public int mLines;


        private UserData()
        {
            mLevel = 0;
            mScore = 0;
            mLines = 0;
        }

        public void AddScore(int numberOfLines)
        {
            switch (numberOfLines)
            {
                case 1:
                    mScore += 1;
                    break;
                case 2:
                    mScore += 3;
                    break;
                case 3:
                    mScore += 5;
                    break;
                case 4:
                    mScore += 7;
                    break;
                default:
                    Debug.LogError("[UserData]: Wrong numberOfLines");
                    break;
            }


            if (AppRoot.Instance.State == AppRoot.Instance.GetState(EAppStateId.Game))
            {
                GameObject score = GameObject.Find("Score");
                score.GetComponent<UnityEngine.UI.Text>().text = mScore.ToString();
            }

        }

        public void AddLines() 
        {
            mLines++;
            if (AppRoot.Instance.State == AppRoot.Instance.GetState(EAppStateId.Game))
            {
                GameObject lines = GameObject.Find("Lines");
                lines.GetComponent<UnityEngine.UI.Text>().text = mLines.ToString();
            }
        }
    }
}
