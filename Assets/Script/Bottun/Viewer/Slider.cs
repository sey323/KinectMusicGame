using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slider : MonoBehaviour {

	UnityEngine.UI.Slider slider;
	private GameObject Score;
	private Score score;

	// Use this for initialization
	void Start () {
		Score = GameObject.FindGameObjectWithTag("Score");
		score = Score.GetComponent<Score>();

		slider = GetComponent<UnityEngine.UI.Slider> ();

	}
	//float i;
	// Update is called once per frame
	void Update () {
		int i = score.getScore();
		slider.value = i;
	}
}
