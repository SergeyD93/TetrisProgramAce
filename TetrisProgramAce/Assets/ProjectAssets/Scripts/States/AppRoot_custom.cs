using System.Collections;
using UnityEngine;

namespace Tetris
{
    public partial class AppRoot : MonoBehaviour
    {
        void OnLevelWasLoaded(int level)
        {
            if (mCurState != null)
            {
                mCurState.OnLevelWasLoaded(level);
            }
        }
        public void StartChildCoroutine(IEnumerator coroutineMethod)
        {
            StartCoroutine(coroutineMethod);
        }
    }
}
