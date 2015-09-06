using UnityEngine;
using System.Collections;

public interface IStateData
{

}

namespace Tetris
{
    public class AppState : MonoBehaviour
    {

        public EAppStateId mId;

        public virtual void Activate(IStateData data, bool resetState)
        {

        }

        public void Deactivate()
        {

        }

        public void Update()
        {

        }

        public void Initialize()
        {

        
        }

        public void OnGUI()
        {
        
        }

        public void OnUiAction(GameObject pressedGo, object p)
        {
        
        }
    }
}
