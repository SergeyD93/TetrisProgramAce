using UnityEngine;
using System.Collections;

namespace Tetris
{
    public class IfigureController : AbstractFigureController
    {
        public IfigureController() : base()
        {
        
        }

        public IfigureController(GameObject figure) : base(figure)
        {
        
        }

        protected override void InitPositions()
        {
            mNumOfPositions = 2;

            cubesPositionsDictionary0.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary0.Add(Cube1, new Vector2(0, 1));
            cubesPositionsDictionary0.Add(Cube2, new Vector2(0, 2));
            cubesPositionsDictionary0.Add(Cube3, new Vector2(0, -1));

            cubesPositionsDictionary1.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary1.Add(Cube1, new Vector2(1, 0));
            cubesPositionsDictionary1.Add(Cube2, new Vector2(2, 0));
            cubesPositionsDictionary1.Add(Cube3, new Vector2(-1, 0));

            mPositionsList.Add(cubesPositionsDictionary0);
            mPositionsList.Add(cubesPositionsDictionary1);

        }

        protected override bool CheckCanRotate()
        {
            float rayDistance0 = 2.0f;
            float rayDistance1 = 1.0f;

            Ray ray0 = new Ray();
            Ray ray1 = new Ray();

            ray0.origin = Cube0.transform.position;
            ray1.origin = Cube0.transform.position;

            switch (mPositionIndex)
            {
                case 0:
                    ray0.direction = Vector3.right;
                    ray1.direction = Vector3.left;
                    break;
                case 1:
                    ray0.direction = Vector3.up;
                    ray1.direction = Vector3.down;
                    break;
                
                default:
                    Debug.LogError("Wrong mPositionIndex");
                    break;
            }
            bool trigegr0 = CheckRaycastHit(ray0, rayDistance0);
            bool trigegr1 = CheckRaycastHit(ray1, rayDistance1);

            if (trigegr0 == true || trigegr1 == true)
            {
                return false;
            }

            return true;
        }
    }
}
