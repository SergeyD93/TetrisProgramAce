using UnityEngine;
using System.Collections;

public class FigureCreator : MonoBehaviour 
{

    public GameObject mFihure;
	// Use this for initialization
	void Start () 
    {
        if(mFihure != null)
        {
            Instantiate(mFihure);
            mFihure.transform.position = transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
