using UnityEngine;
using System;
using System.Collections;
using MiniJSON;
using UnityEngine.SceneManagement;


public class Spowner : MonoBehaviour {

    //現在のシーン名
    private string nowSceneName;

    //音用
    public int inote = 0;
    public IList notes = null;
    public int bpm = 0;//alien: 140, close the light: 175, nether :190
    public string keysound;
    public double sounds;
    private bool startflag = false;
    
    //初期設定用キーカウンター
    private string keycounter;
    public int[] keyCopunts = new int[8];
    public int keyValue;//キー個数 

    //画面遷移用
    private Score score;
    public int nowKey;

    //ノードのTransformの初期化
    public Transform A;
	public Transform B;
	public Transform C;
    public Transform D;
    public Transform E;
    public Transform F;
    public Transform G;
    public Transform H;
    public Transform Sound;
    TextAsset asset = null;

    private Vector3 vec3;
    private bool isRunning=false;

    // Use this for initialization
    void Start()
    {
        GameController.endFlag = false;
        nowSceneName = Application.loadedLevelName;

        inote = 0;
        keysound = null;
        sounds = 0;

        //モード判定と画面遷移設定
        //GameController.skipFlag = false;
        //GameController.nextScene = "Menu";

        if (nowSceneName == "GameModeEasy")
        {
            asset = (TextAsset)Resources.Load("2016/alien_techno");
            bpm = 140;
        }
        else if (nowSceneName == "GameModeMiddle")
        {
            asset = (TextAsset)Resources.Load("2016/closethelight_techno");
            bpm = 175;
        }
        else if (nowSceneName == "GameModeHard")
        {
            asset = (TextAsset)Resources.Load("2016/nether_techno");
            bpm = 190;
        }
        else if (nowSceneName == "Tutorial")
        {
            asset = (TextAsset)Resources.Load("Metronome/metodemo");
            bpm = 86;
        }

        //jsonの取得
        string json = asset.text;
        notes = (IList)Json.Deserialize(json);

        //キーのカウント
        for (int i = 0; i < notes.Count; i++)
        {
            IDictionary note = (IDictionary)notes[i];
            keycounter = (string)note["key"];
            switch (keycounter)
            {
                case "0":
                    keyCopunts[0]++;
                    keyValue++;
                    break;
                case "1":
                    keyCopunts[1]++;
                    keyValue++;
                    break;
                case "2":
                    keyCopunts[2]++;
                    keyValue++;
                    break;
                case "3":
                    keyCopunts[3]++;
                    keyValue++;
                    break;
                case "4":
                    keyCopunts[4]++;
                    keyValue++;
                    break;
                case "5":
                    keyCopunts[5]++;
                    keyValue++;
                    break;
                case "6":
                    keyCopunts[6]++;
                    keyValue++;
                    break;
                case "7":
                    keyCopunts[7]++;
                    keyValue++;
                    break;

                default: break;
            }
        }
        //ノートの飛ぶ位置の修正
        vec3 = new Vector3(0, 0, 70);

        //スコアボードの取得
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        score.setScore(GameController.totalScore);
        //StartCoroutine("waitOpening", isRunning);

    }

    // Update is called once per frame
    void Update () {
      
        //Jsonを配列に代入しループ
        while (inote < notes.Count)
        {
            IDictionary note = (IDictionary)notes[inote];
            if (60 * 4 * (double)note["start"] > bpm * (Time.timeSinceLevelLoad))
            {
                break;
            }
            keysound = (string)note["key"];
            sounds = (double)note["start"];
            CreateNote(keysound);
            if (!startflag)
            {
                startSound(sounds);
            }
            inote++;
        }

        //キーノードがすべて出たか確認
        if (nowKey >= keyValue)
        {
            StartCoroutine("resultScene",5);
        }

        //裏コード中断するとき
        if (Input.GetKey("space"))
        {
            GameController.endFlag = true;
            StartCoroutine("resultScene",3);
        }

        //裏コード中断するとき
        if (Input.GetKeyDown(KeyCode.A))
        {
            score.setScore(10);
        }

        //裏コード中断するとき（最高点）
        if (Input.GetKeyDown(KeyCode.C))
        {
            score.setScore(1000);
            GameController.endFlag = true;
            StartCoroutine("resultScene", 3);
        }

    }

    /// <summary>
    /// Keysoundによってノードを生成
    /// </summary>
    /// <param name="keysound"></param>
    private void CreateNote(string keysound)
    {
        switch (keysound)
        {
            case "0":
                Instantiate(A, vec3, Quaternion.identity);
                nowKey++;
                break;
            case "1":
                Instantiate(B, vec3, Quaternion.identity);
                nowKey++;
                break;
            case "2":
                Instantiate(C, vec3, Quaternion.identity);
                nowKey++;
                break;
            case "3":
                Instantiate(D, vec3, Quaternion.identity);
                nowKey++;
                break;
            case "4":
                Instantiate(E, vec3, Quaternion.identity);
                nowKey++;
                break;
            case "5":
                Instantiate(F, vec3, Quaternion.identity);
                nowKey++;
                break;
            case "6":
                Instantiate(G, vec3, Quaternion.identity);
                nowKey++;
                break;
            case "7":
                Instantiate(H, vec3, Quaternion.identity);
                nowKey++;
                break;

            default: break;
        }
    }


    /// <summary>
    /// スタートサウンドの発生
    /// </summary>
    /// <param name="sounds"></param>
    private void startSound(double sounds)
    {
        if (GameController.nextSceneName == "GameModeHard" && sounds == 1.0)//alien: 0.0, close the light: 0.0, nether : 1.0
        {
            Instantiate(Sound, new Vector3(0, 0, 70), Quaternion.identity);
        }
        else //if (sounds == 0.0)//alien: 0.0, close the light: 0.0, nether : 1.0
        {
            Instantiate(Sound, new Vector3(0, 0, 70), Quaternion.identity);
        }
        startflag = true;
    }


    /// <summary>
    /// ゲーム結果へのシーン遷移
    /// </summary>
    /// <returns></returns>
    private IEnumerator resultScene(float time)
    {
        GameController.totalScore = score.getScore();
        //チュートリアルモードのときの処
        if( nowSceneName == "Tutorial")
        {
            GameController.Play();
        }

        yield return new WaitForSeconds(time);

        GameController.endFlag = true;
        //クリアか判定
        if (score.isClear())
        {
            GameController.clearFlag = true;
      
        }
        else
        {
            GameController.clearFlag = false;
        }

        yield return new WaitForSeconds(time);

        GameController.Play();
    }

}