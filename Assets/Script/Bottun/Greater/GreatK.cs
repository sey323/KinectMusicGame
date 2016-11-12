using UnityEngine;
using System.Collections;

public class GreatK : MonoBehaviour
{
    private bool greatanotate;
    private bool goodFlag;
    private ParticleSystem greatParticle;
    private ButtonElem btn;

    private GameObject ScoreBoad;
    private Score score;

    void Start()
    {
        greatParticle = GetComponent<ParticleSystem>();
        btn = GetComponent<ButtonElem>();
        ScoreBoad = GameObject.FindGameObjectWithTag("Score");
        score = ScoreBoad.GetComponent<Score>();
    }


    public void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.K) || btn.isEnter())
        {
            //print("Greeeeeeeeeeeeeeeeaaaaaaaaaaaat");
            if (other.gameObject.tag == "Great")
            {
                score.setScore(5);
                greatParticle.Play();
                greatanotate = true;
            }
            if (other.gameObject.tag == "Good")
            {
                goodFlag = true;
            }
            if (other.gameObject.transform.root.tag == "Quad")
            {
                Destroy(other.gameObject.transform.root.gameObject);
            }
        }
    }

    /// <summary>
    /// Greatゲッター
    /// </summary>
    /// <returns></returns>
    public bool isGreat()
    {
        return greatanotate;
    }

    /// <summary>
    /// Goodゲッター
    /// </summary>
    /// <returns></returns>
    public bool isGood()
    {
        return goodFlag;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void initialize()
    {
        greatanotate = false;
        goodFlag = false;
    }
}

