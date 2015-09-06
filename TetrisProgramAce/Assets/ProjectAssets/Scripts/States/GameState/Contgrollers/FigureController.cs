using UnityEngine;
using System.Collections;

public class FigureController : MonoBehaviour {

    private Vector3 mPreviosPosition;
	// Use this for initialization
	void Start ()
    {
        mPreviosPosition = transform.position;
        Move();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mPreviosPosition = transform.position;
            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mPreviosPosition = transform.position;
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            mPreviosPosition = transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90, transform.rotation.w);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }

    }

    private void Move() 
    {
        StartCoroutine("TakeStep");
    }

    IEnumerator TakeStep()
    {
        yield return new WaitForSeconds(0.5f);
        mPreviosPosition = transform.position;
        transform.position = new Vector2(transform.position.x, transform.position.y -1);
        StartCoroutine("TakeStep");
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.position = mPreviosPosition;
        StopCoroutine("TakeStep");
    }
}
