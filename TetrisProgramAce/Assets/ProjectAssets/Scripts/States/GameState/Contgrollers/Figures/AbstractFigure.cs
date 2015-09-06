using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractFigure : MonoBehaviour 
{
    protected Dictionary<GameObject, Vector2> cubesPositionsDictionary0 = new Dictionary<GameObject, Vector2>();
    protected Dictionary<GameObject, Vector2> cubesPositionsDictionary1 = new Dictionary<GameObject, Vector2>();
    protected Dictionary<GameObject, Vector2> cubesPositionsDictionary2 = new Dictionary<GameObject, Vector2>();
    protected Dictionary<GameObject, Vector2> cubesPositionsDictionary3 = new Dictionary<GameObject, Vector2>();

    protected GameObject Cube0;
    protected GameObject Cube1;
    protected GameObject Cube2;
    protected GameObject Cube3;

    protected List<Dictionary<GameObject, Vector2>> mPositionsList;
    List<GameObject> mDetailsList;

    protected int mPositionIndex = 0;
    protected int mNumOfPositions;

    protected void Start()
    {
        Cube0 = transform.FindChild("Cube0").gameObject;
        Cube1 = transform.FindChild("Cube1").gameObject;
        Cube2 = transform.FindChild("Cube2").gameObject;
        Cube3 = transform.FindChild("Cube3").gameObject;

        mDetailsList = new List<GameObject>();

        mDetailsList.Add(Cube0);
        mDetailsList.Add(Cube1);
        mDetailsList.Add(Cube2);
        mDetailsList.Add(Cube3);

        mPositionsList = new List<Dictionary<GameObject, Vector2>>();
        InitPositions();
        StartCoroutine("TakeStep"); //start moving
    }

    protected abstract void InitPositions();

    IEnumerator TakeStep()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 1);

        yield return new WaitForSeconds(0.5f);

        if (CheckBottomCollisiom() == false)
        {
            StartCoroutine("TakeStep");
        }
        else
        {
            this.tag = "Untagged";
            foreach (GameObject cube in mDetailsList)
            {
                cube.tag = "Untagged";
            }
        }
    }

    protected void Update ()
    {
        CheckPressedKeys();
    }

    void CheckPressedKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) //Input.GetKeyDown(KeyCode.Space))
        {
            RotateFigure();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckCanRotate();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
    }

    void MoveLeft()
    {
        if (CheckCanOffset(Vector3.left) == true)
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
        }
    }

    void MoveRight()
    {
        if (CheckCanOffset(Vector3.right) == true)
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
    }

    void RotateFigure()
    {
        if (CheckCanRotate() == true)
        {
            if (mNumOfPositions != null)
            {
                mPositionIndex++;
                if (mPositionIndex >= mNumOfPositions)
                {
                    mPositionIndex = 0;
                }
            }
            else
            {
                Debug.LogError("Determine mNumOfPositions in child");
            }

            foreach (KeyValuePair<GameObject, Vector2> cube in mPositionsList[mPositionIndex])
            {
                cube.Key.transform.localPosition = cube.Value;
            }
        }
    }

    protected abstract bool CheckCanRotate();

    bool CheckBottomCollisiom()
    {
        Vector3 direction = Vector3.down;
        foreach (GameObject cube in mDetailsList)
        {
            Ray ray = new Ray(cube.transform.position, direction);
            bool rayHited = CheckRaycastHit(ray, 1.0f);
            if (rayHited == true)
            {
                return true;
            }
        }
        return false;
    }

    bool CheckCanOffset(Vector3 direction) 
    {
        if(this.tag != "CurentFigure")
        {
            return false;
        }

        foreach(GameObject cube in mDetailsList)
        {
            Ray ray = new Ray(cube.transform.position, direction);
            bool rayHited = CheckRaycastHit(ray, 1.0f);
            if (rayHited == true)
            {
                return false;
            }
        }
        return true;
    }

    protected bool CheckRaycastHit(Ray ray, float rayDistance)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.transform.tag != "CurentFigure")
            {
                Debug.Log(this.name + " ray hit: " + hit.transform.name);
                return true;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red, rayDistance);
        return false;
    }
}
