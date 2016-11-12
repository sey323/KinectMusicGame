using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour {

    public Text scoreboad;
  

	// Use this for initialization
	void Start () {
        scoreboad.text = scoreboad.text + GameController.totalScore.ToString() + "点";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
