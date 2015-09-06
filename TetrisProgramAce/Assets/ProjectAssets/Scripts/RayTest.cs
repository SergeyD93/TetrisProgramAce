using UnityEngine;
using System.Collections;

public class RayTest : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Ray ray = new Ray(new Vector2(transform.position.x, transform.position.y) + cube.Value, Vector3.right);
        Ray ray = new Ray(new Vector2(transform.position.x, transform.position.y), Vector3.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            Debug.Log("hit: " + hit.transform.name);
               /* if (hit.transform.tag != "CurentFigure")
                {

                }*/
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1.0f);
    }
}
