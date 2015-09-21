using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tetris
{
    public class FiguresGenerator
    {
        private Dictionary<System.Type, string> mFiguresDictionary;
        private  System.Random mRandom;
        private int mNextFigureIndex;

        public FiguresGenerator()
        {
            mRandom = new System.Random();
            mFiguresDictionary = new Dictionary<System.Type, string>();

            mFiguresDictionary.Add(typeof(IfigureController), "Figures/Ifigure");
            mFiguresDictionary.Add(typeof(JfigureController), "Figures/Jfigure");
            mFiguresDictionary.Add(typeof(LfigureController), "Figures/Lfigure");
            mFiguresDictionary.Add(typeof(OfigureController), "Figures/Ofigure");
            mFiguresDictionary.Add(typeof(SfigureController), "Figures/Sfigure");
            mFiguresDictionary.Add(typeof(TfigureController), "Figures/Tfigure");
            mFiguresDictionary.Add(typeof(ZfigureController), "Figures/Zfigure");
        }

        GameObject LoadFigure(string path)
        {
            GameObject tempFifure = Resources.Load(path) as GameObject;

            if (tempFifure != null)
            {
                return tempFifure;
            }

            Debug.LogError("[FiguresCreator]: tempFifure is null, bad path: " + path);
            return null;
        }

        private void GenerateNextFigure()
        {
            mNextFigureIndex = mRandom.Next(0, mFiguresDictionary.Count);
        }

        public void GetFigurePathAndControllerType(out AbstractFigureController controller, out string path)
        {
            GenerateNextFigure();
            int counter = 0;

            foreach(KeyValuePair<System.Type, string> elem in mFiguresDictionary)
            {
                if (counter == mNextFigureIndex)
                {
                    controller = System.Activator.CreateInstance(elem.Key) as AbstractFigureController;
                    path = elem.Value;
                    return;
                }
                counter++;
            }
            controller = null;
            path = null;
        }
    }
}