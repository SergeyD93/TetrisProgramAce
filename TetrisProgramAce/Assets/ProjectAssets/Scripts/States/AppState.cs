using UnityEngine;
using System.Collections;

public interface IStateData
{

}

namespace Tetris
{
    public abstract class AppState
    {

        public EAppStateId mId;

        public abstract void Activate(IStateData data, bool resetState);

        public void Deactivate()
        {

        }

        public virtual void Update()
        {

        }

        public void Initialize()
        {
        
        }


        public void OnGUI()
        {
        
        }

        public virtual void OnLevelWasLoaded(int level)
        {
        
        }


        public void OnUiAction(GameObject pressedGo, object p)
        {
        
        }
    }
}
