using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
    public class FiguresManager
    {
        private GameObject mFigure0;
        private GameObject mFigure1;
        private GameObject mCurentFigure;
        
        private AbstractFigureController mCurentFigureController;
        private AbstractFigureController mNextFigureController;

        private FiguresGenerator mFiguresCreator;
        private BlocksDestroyer mBlocksDestroyer;

        private List<int> mPositionsForDestroyingList;
        private List<GameObject> mBlocksForDestroying;
        private string mPathToFigure;

        public FiguresManager()
        {
            mFiguresCreator = new FiguresGenerator();
            mBlocksDestroyer = new BlocksDestroyer();
            mBlocksDestroyer.BlockDestroyed += OnAllBlocksDestroyed;

            CreateFigure();
        }

        /*void Create1Figure()
        {
            mFiguresCreator.GetFigurePathAndControllerType (out mCurentFigureController, out mPathToFigure);

            if (mCurentFigureController == null || mPathToFigure == null)
            {
                Debug.LogError("[FiguresManager]: mCurentFigureController or mPathToFigure is null");
            }
            else
            {
                if (mFigure0 != mCurentFigure)
                {
                    mFigure0 = LoadFigure(mPathToFigure);
                    if (mFigure0 != null)
                    {
                        mFigure0.transform.position = new Vector2(0, 22);
                        mCurentFigureController.SetFigure(mFigure0);
                        mCurentFigureController.FigureDropped += CheckFullLines;
                    }
                    else
                    {
                        Debug.LogError("[FiguresManager]: mFigure is null");
                    }
                }
                else
                {
                    mFigure1 = LoadFigure(mPathToFigure);
                    if (mFigure1 != null)
                    {
                        mFigure1.transform.position = new Vector2(0, 22);
                        mCurentFigureController.SetFigure(mFigure1);
                        mCurentFigureController.FigureDropped += CheckFullLines;
                    }
                    else
                    {
                        Debug.LogError("[FiguresManager]: mFigure is null");
                    }
                }
                
            }
        }*/

        void CreateFigure()
        {
            mFiguresCreator.GetFigurePathAndControllerType(out mNextFigureController, out mPathToFigure);
            if (mNextFigureController == null || mPathToFigure == null)
            {
                Debug.LogError("[FiguresManager]: mNextFigureController or mPathToFigure is null");
            }
            else
            {
                if (mFigure0 != mCurentFigure)
                {
                    mFigure0 = LoadFigure(mPathToFigure);
                    if (mFigure0 != null)
                    {
                        mFigure0.transform.position = new Vector2(10, 15);
                        mCurentFigure = mFigure0;
                    }
                    else
                    {
                        Debug.LogError("[FiguresManager]: mCurentFigure is null");
                    }
                }
                else
                {
                    mFigure1 = LoadFigure(mPathToFigure);
                    if (mFigure1 != null)
                    {
                        mFigure1.transform.position = new Vector2(10, 15);
                        mFigure1.transform.position = new Vector2(10, 15);
                    }
                    else
                    {
                        Debug.LogError("[FiguresManager]: mCurentFigure is null");
                    }
                }
            }
            if(mCurentFigureController == null)
            {
                SetCurentFigure();
                //CreateFigure();
            }
        }

        void SetCurentFigure()
        {
            if(mFigure0 != mCurentFigure)
            {
                mCurentFigureController = mNextFigureController;
                mFigure0.transform.position = new Vector2(0, 22);
                mCurentFigureController.SetFigure(mFigure0);
                mCurentFigureController.FigureDropped += CheckFullLines;
            }
            else
            {
                mCurentFigureController = mNextFigureController;
                mFigure1.transform.position = new Vector2(0, 22);
                mCurentFigureController.SetFigure(mFigure1);
                mCurentFigureController.FigureDropped += CheckFullLines;
            }
            CreateFigure();
        }

        GameObject LoadFigure(string path)
        {
            return GameObject.Instantiate(Resources.Load(path) as GameObject);
        }

        public void Update()
        {
            mCurentFigureController.CheckPressedKeys();
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
                //CreateFigure();
                SetCurentFigure();
            }
        }

        private void OnAllBlocksDestroyed()
        {
            MoveBlocksDown(mPositionsForDestroyingList);
            DestroyEmptyFigures();
            SetCurentFigure();
            //CreateFigure();
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
