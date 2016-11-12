using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour {

	public static bool badanotate;
    private Score score;
    private GameObject ScoreBoad;

    void Start()
    {
        ScoreBoad = GameObject.FindGameObjectWithTag("Score");
        score = ScoreBoad.GetComponent<Score>();
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.root.gameObject);
        //print("destroy");
        score.downScore(3);

        badanotate = true;
    }
}
