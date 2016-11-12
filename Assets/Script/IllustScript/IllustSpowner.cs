using UnityEngine;
using System.Collections;

public class IllustSpowner : MonoBehaviour {


	private Vector3 vec3;

    //ランダムにノーツを生成するための配列
    //public GameObject[] Notes;
    public GameObject Note;//ここに入れたオブジェクトをカットイ
    private GameObject Score;
	private Score score;
    
    //カットインを出す範囲
    public double underLength;//この値以上になったときに出現

	private bool flag;
    public bool clearshorter = false;
    public bool missshorter = false;

	// Use this for initialization
	void Start () {
		vec3 = new Vector3(-100, 0,5);

		Score = GameObject.FindGameObjectWithTag("Score");
		score = Score.GetComponent<Score>();

		flag = true;
	}
	
	// Update is called once per frame
	void Update () {
        //number = Random.Range(0,Notes.Length);
        if (flag)
        {
            if (score.getPointRate() > underLength && !GameController.endFlag)
            {
                Instantiate(Note, vec3, Quaternion.identity);
                flag = false;
            }
            else if (GameController.endFlag)
            {
                callshorter();
            }
        }
	}

    /// <summary>
    /// resultshorterを呼ぶ
    /// </summary>
    public void callshorter()
    {
        vec3 = new Vector3(-50, 10, -5);

        if (clearshorter && GameController.clearFlag && score.isClear())
        {
            Instantiate(Note, vec3, Quaternion.identity);
            flag = false;
        }
        else if (missshorter && !GameController.clearFlag && !score.isClear())
        {
            Instantiate(Note, vec3, Quaternion.identity);
            flag = false;
        }
    }
}
