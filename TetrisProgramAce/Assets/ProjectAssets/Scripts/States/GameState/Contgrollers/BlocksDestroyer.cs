using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Tetris
{
    public class BlocksDestroyer
    {
        public event EventDelegate BlockDestroyed;

        private float mAlpha;
        private float mAplhaStep = 0.02f;

        public BlocksDestroyer()
        {

        }

        public void DestroyBlock(List<GameObject> blocks)
        {
            if (blocks.Count > 0)
            {
                mAlpha = blocks[0].GetComponent<Renderer>().material.color.a;
                AppRoot.Instance.StartChildCoroutine(TransparateBlock(blocks));
            }
        }

        IEnumerator TransparateBlock(List<GameObject> blocks)
        {
            yield return new WaitForSeconds(0.1f);
            if (mAlpha > 0)
            {
                foreach(GameObject block in blocks)
                {
                    mAlpha -= mAplhaStep;

                    Color color = new Color(block.GetComponent<Renderer>().material.color.r, block.GetComponent<Renderer>().material.color.g, block.GetComponent<Renderer>().material.color.b, mAlpha);
                    Renderer rend = block.GetComponent<Renderer>();
                    rend.material.SetColor("_Color", color);
                    
                }
                AppRoot.Instance.StartChildCoroutine(TransparateBlock(blocks));
            }
            else
            {
                foreach (GameObject block in blocks)
                {
                    GameObject.Destroy(block);
                }
                BlockDestroyed();
            }
        }

    }
}