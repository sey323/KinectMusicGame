using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public GUIText Scotx;
    private int score;
    public int baseScore;
    public double pointRate;

    private bool clearFlag;

    //スポーナから最大値の取得
    public GameObject Spowner;
    private Spowner spowner;
    private int MaxPoint;

    void Start()
    {
        spowner = Spowner.GetComponent<Spowner>();
        MaxPoint = spowner.keyValue * 3;
        clearFlag = false;
        baseScore = getScore() - GameController.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        Scotx.text = getScore().ToString();
        pointRate = (double) baseScore / MaxPoint;
    }

    /// <summary>
    /// ゲッター
    /// </summary>
    /// <returns></returns>
    public int getScore()
    {
        return score;
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    /// <param name="point"></param>
    public void setScore( int point)
    {
        score += point;
        baseScore += point;
    }

    /// <summary>
    /// スコア減算
    /// </summary>
    /// <param name="point"></param>
    public void downScore( int point)
    {
        score -= point;
        baseScore -= point;
    }

    /// <summary>
    /// 得点の比率を返す
    /// </summary>
    /// <returns></returns>
    public double getPointRate()
    {
        return pointRate;
    }

    public bool isClear()
    {
        if (pointRate > 0.6)
        {
            clearFlag = true;
        }
        GameController.clearFlag = clearFlag;
        return clearFlag;
    }
}
