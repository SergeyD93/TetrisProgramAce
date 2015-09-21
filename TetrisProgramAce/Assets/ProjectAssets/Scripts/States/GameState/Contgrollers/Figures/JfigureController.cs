using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tetris
{
    public class JfigureController : AbstractFigureController
    {
        public JfigureController()
        {
        
        }

        public JfigureController(GameObject figure) : base(figure)
        {

        }

        protected override void InitPositions()
        {
            mNumOfPositions = 4;

            cubesPositionsDictionary0.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary0.Add(Cube1, new Vector2(0, 1));
            cubesPositionsDictionary0.Add(Cube2, new Vector2(0, -1));
            cubesPositionsDictionary0.Add(Cube3, new Vector2(-1, -1));

            cubesPositionsDictionary1.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary1.Add(Cube1, new Vector2(1, 0));
            cubesPositionsDictionary1.Add(Cube2, new Vector2(-1, 0));
            cubesPositionsDictionary1.Add(Cube3, new Vector2(-1, 1));

            cubesPositionsDictionary2.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary2.Add(Cube1, new Vector2(0, -1));
            cubesPositionsDictionary2.Add(Cube2, new Vector2(0, 1));
            cubesPositionsDictionary2.Add(Cube3, new Vector2(1, 1));

            cubesPositionsDictionary3.Add(Cube0, new Vector2(0, 0));
            cubesPositionsDictionary3.Add(Cube1, new Vector2(-1, 0));
            cubesPositionsDictionary3.Add(Cube2, new Vector2(1, 0));
            cubesPositionsDictionary3.Add(Cube3, new Vector2(1, -1));

            mPositionsList.Add(cubesPositionsDictionary0);
            mPositionsList.Add(cubesPositionsDictionary1);
            mPositionsList.Add(cubesPositionsDictionary2);
            mPositionsList.Add(cubesPositionsDictionary3);
        }

        protected override bool CheckCanRotate()
        {
            float rayDistance = 1.0f;

            Ray ray0 = new Ray();
            Ray ray1 = new Ray();
            Ray ray2 = new Ray();

            ray0.origin = Cube0.transform.position;
            ray1.origin = Cube0.transform.position;
            ray2.origin = Cube1.transform.position;

            switch (mPositionIndex)
            {
                case 0:
                    ray0.direction = Vector3.left;
                    ray1.direction = Vector3.right;
                    ray2.direction = Vector3.left;
                    break;
                case 1:
                    ray0.direction = Vector3.up;
                    ray1.direction = Vector3.down;
                    ray2.direction = Vector3.up;
                    break;
                case 2:
                    ray0.direction = Vector3.right;
                    ray1.direction = Vector3.left;
                    ray2.direction = Vector3.right;
                    break;
                case 3:
                    ray0.direction = Vector3.down;
                    ray1.direction = Vector3.up;
                    ray2.direction = Vector3.down;
                    break;
                default:
                    Debug.LogError("Wrong mPositionIndex");
                    break;
            }
            bool trigegr0 = CheckRaycastHit(ray0, rayDistance);
            bool trigegr1 = CheckRaycastHit(ray1, rayDistance);
            bool trigegr2 = CheckRaycastHit(ray2, rayDistance);

            if (trigegr0 == true || trigegr1 == true || trigegr2 == true)
            {
                return false;
            }

            return true;
        }
    }
}
