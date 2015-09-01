using UnityEngine;
using System.Collections;

public class ShaderUsing : MonoBehaviour {

    float alpha;
    float alphaDelta = 0.05f;
	void Start () 
    {
        alpha = gameObject.GetComponent<Renderer>().material.color.a;
        StartCoroutine(TestCoroutine());
	}

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (alpha > 0)
        {
            alpha -= alphaDelta;

            Color color = new Color(gameObject.GetComponent<Renderer>().material.color.r, gameObject.GetComponent<Renderer>().material.color.g, gameObject.GetComponent<Renderer>().material.color.b, alpha);
            Renderer rend = gameObject.GetComponent<Renderer>();
            rend.material.SetColor("_Color", color);
            StartCoroutine(TestCoroutine());
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
