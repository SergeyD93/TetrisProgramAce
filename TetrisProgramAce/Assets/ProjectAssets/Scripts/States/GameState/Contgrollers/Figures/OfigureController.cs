using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class OfigureController : AbstractFigureController
    {
        public OfigureController()
        {
        
        }

        public OfigureController(GameObject figure) : base(figure)
        {
        
        }

        protected override void InitPositions()
        {
            mNumOfPositions = 0;
        }

        protected override bool CheckCanRotate()
        {
            return false;
        }
    }
}
