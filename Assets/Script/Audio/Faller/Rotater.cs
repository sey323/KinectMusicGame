using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (500 * Time.deltaTime, 250 * Time.deltaTime, 250 * Time.deltaTime);
	}
}
