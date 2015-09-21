using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tetris
{
    public class TfigureController : AbstractFigureController 
    {
        public TfigureController()
        {
        
        }

        public TfigureController(GameObject figure) : base(figure)
        {

        }

        protected override void InitPositions()
        {
            mNumOfPositions = 4;

            cubesPositionsDictionary0.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary0.Add(Cube1, new Vector2(-1, 0));
            cubesPositionsDictionary0.Add(Cube2, new Vector2(0, 1));
            cubesPositionsDictionary0.Add(Cube3, new Vector2(1, 0));

            cubesPositionsDictionary1.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary1.Add(Cube1, new Vector2(0, -1));
            cubesPositionsDictionary1.Add(Cube2, new Vector2(0, 1));
            cubesPositionsDictionary1.Add(Cube3, new Vector2(1, 0));

            cubesPositionsDictionary2.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary2.Add(Cube1, new Vector2(-1, 0));
            cubesPositionsDictionary2.Add(Cube2, new Vector2(0, -1));
            cubesPositionsDictionary2.Add(Cube3, new Vector2(1, 0));

            cubesPositionsDictionary3.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary3.Add(Cube1, new Vector2(-1, 0));
            cubesPositionsDictionary3.Add(Cube2, new Vector2(0, 1));
            cubesPositionsDictionary3.Add(Cube3, new Vector2(0, -1));

            mPositionsList.Add(cubesPositionsDictionary0);
            mPositionsList.Add(cubesPositionsDictionary1);
            mPositionsList.Add(cubesPositionsDictionary2);
            mPositionsList.Add(cubesPositionsDictionary3);
        }

        protected override bool CheckCanRotate()
        {
            float rayDistance = 1.0f;

            Ray ray0 = new Ray();

            ray0.origin = Cube0.transform.position;

            switch (mPositionIndex)
            {
                case 0:
                    ray0.direction = Vector3.down;
                    break;
                case 1:
                    ray0.direction = Vector3.left;
                    break;
                case 2:
                    ray0.direction = Vector3.up;
                    break;
                case 3:
                    ray0.direction = Vector3.right;
                    break;
                default:
                    Debug.LogError("Wrong mPositionIndex");
                    break;
            }
            bool trigegr0 = CheckRaycastHit(ray0, rayDistance);

            if (trigegr0 == true)
            {
                return false;
            }

            return true;
        }
    }
}
