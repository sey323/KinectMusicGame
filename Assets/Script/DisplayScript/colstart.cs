using UnityEngine;
using System.Collections;

public class colstart : MonoBehaviour {
    public GameObject gazou;
    public Material mat;
    public Color iro;
    public Renderer ren;
    float x;

	// Use this for initialization
	void Start () {
        x = 0;
        //iro = new Color(0, 0, 0, 0);
        gazou = GameObject.Find("title");
        ren = gazou.GetComponent<Renderer>();
        ren.material.color = iro;

        StartCoroutine("start");
   
    }

 
    IEnumerator start()
    {
       
        while (x <= 1)
        {
            x = x + 0.1f;
            iro.a = x;
            ren.material.color = iro;
            yield return 0;
            //Debug.Log("aaaaaaaaa");
        }
        yield return new WaitForSeconds(1.7f);
        while (x >= 0)
        {
            x = x - 0.05f;
            iro.a = x;
            ren.material.color = iro;
            yield return 0;

        }

    }
}
