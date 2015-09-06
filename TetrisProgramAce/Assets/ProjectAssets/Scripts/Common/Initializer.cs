using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class Initializer : MonoBehaviour
    {

        // Use this for initialization
        void Start() 
        {
            AppRoot.Instance.SetState(EAppStateId.MainMenu);
	    }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
