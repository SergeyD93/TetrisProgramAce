using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
    public class FiguresManager
    {
        private GameObject mFigure;
        private GameObject mCurentFigure;
        private BlocksDestroyer mBlocksDestroyer;
        private AbstractFigureController mCurentFigureController;

        private List<int> mPositionsForDestroyingList;
        private List<GameObject> mBlocksForDestroying;

        public FiguresManager()
        {
            CreateFigure();

            mBlocksDestroyer = new BlocksDestroyer();
            mBlocksDestroyer.BlockDestroyed += OnAllBlocksDestroyed;

        }

        public void Update()
        {
            mCurentFigureController.CheckPressedKeys();
        }

        void CreateFigure()
        {
            mFigure = Resources.Load("Figures/Ifigure") as GameObject;

            if (mFigure != null)
            {
                
                mCurentFigure = GameObject.Instantiate(mFigure);
                mCurentFigureController = new IfigureController(mCurentFigure);

                mCurentFigureController.FigureDropped += CheckFullLines;
                mCurentFigure.transform.position = new Vector2(0, 22);
                
            }
            else
            {
                Debug.LogError("[FigureCreator]: mFigure is null");
            }
        }

        void CheckFullLines()
        {
            mBlocksForDestroying = new List<GameObject>();
            mPositionsForDestroyingList = new List<int>();

            GameObject wall = GameObject.Find("Wall1");
            RaycastHit[] hits;
            float rayDistance = 10.0f;

            for (int i = 1; i < 21; i++)
            {
                Ray ray = new Ray(new Vector2(wall.transform.position.x, i), Vector3.right);
                hits = Physics.RaycastAll(ray, rayDistance);
                Debug.DrawRay(ray.origin, ray.direction, Color.blue, rayDistance);

                if (hits.Length >= 10)
                {
                    mPositionsForDestroyingList.Add(i);
                    UserData.Instance.AddLines();
                    foreach(RaycastHit hit in hits)
                    {
                        
                        if (hit.collider.gameObject.tag == "DroppedCube")
                        {
                            mBlocksForDestroying.Add(hit.collider.gameObject);
                        }
                    }
                }
            }
            if (mBlocksForDestroying.Count != 0)
            {
                mBlocksDestroyer.DestroyBlock(mBlocksForDestroying);
                UserData.Instance.AddScore(mPositionsForDestroyingList.Count);
            }
            else
            {
                CreateFigure();
            }
        }

        private void OnAllBlocksDestroyed()
        {
            MoveBlocksDown(mPositionsForDestroyingList);
            DestroyEmptyFigures();
            CreateFigure();
        }

        private void MoveBlocksDown(List<int> destroyedPositions)
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("DroppedCube");

            List<int> sortedDestroyedPositions = destroyedPositions.OrderByDescending(obj => obj).ToList();

            foreach (GameObject cube in cubes)
            {
                foreach (int position in sortedDestroyedPositions)
                {
                    if (cube.transform.position.y >= ((float)position + 0.2f))
                    {
                        cube.transform.position = new Vector2(cube.transform.position.x, cube.transform.position.y - 1);
                    }
                }
            }
        }

        private void DestroyEmptyFigures()
        {
            GameObject[] figures = GameObject.FindGameObjectsWithTag("DroppedFigure");
            foreach (GameObject figure in figures)
            {
                if (figure.transform.childCount <= 0)
                {
                    GameObject.Destroy(figure);
                }
            }
        }
    }
}
