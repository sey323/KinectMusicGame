using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static string nowSceneName;//今のゲームシーン
    [SerializeField]
    public static string nextSceneName;//次のゲームシーン
  
    [SerializeField]
    public static string playMovie;//流す動画名
    [SerializeField]
    public static string nextMovie;//動画が連続するとき（ここがnull出ないとき連続して動画を流す）

    public static string fomat = ".ogv";

    public static bool storyFlag;//ストーリーモードかどうか
    public static bool skipFlag;//動画なし
    public static bool clearFlag;//ゲームクリアかどうか
    public static bool endFlag;//ゲーム終了かどうか

    public static bool created = false;

    public static int totalScore = 0;

    // Use this for initialization
    void Awake () {
        //GameContorollerが存在していたら削除
        if (!created)
        {
            DontDestroyOnLoad(this);
            created = true;
        }
        else
        {
            Destroy(this);
        } 
	}


    /// <summary>
    /// Sceneを読み込んだとき
    /// </summary>
    void OnLevelWasLoaded()
    {
        Gesture.setGesturefalse();
        clearFlag = false;

        //Menu画面
        /*
        if (nowSceneName == "Menu")
        {
            skipFlag = false;
            storyFlag = false;
            totalScore = 0;
        }*/
        //Easyモードのとき
        if (nowSceneName == "GameModeEasy")
        {
            if (storyFlag)
            {
                nextSceneName = "GameModeMiddle";
                nextMovie = "MiddleStart";
            }
        }
        //Middleモードのとき
        else if (nowSceneName == "GameModeMiddle")
        {
            if (storyFlag)
            {
                nextSceneName = "GameModeHard";
                nextMovie = "HardStart";
            }
        }
        //Hardモードのとき
        else if (nowSceneName == "GameModeHard")
        {
            if (storyFlag)
            {
                nextSceneName = "KinectScreen";
                nextMovie = "Endding";
            }
        }
        //Tutorialのとき
        else if (nowSceneName == "Tutorial")
        {
            nextSceneName = "Menu";
            skipFlag = true;
        }

        //ストーリーモードでかつ次に再生する動画があるとき
        /*
        if (storyFlag && nextMovie != "")
        {
            playMovie = nextMovie + fomat;
            nextMovie = "";
            nextSceneName = ("movie");
        }*/
        skipFlag = false;
        nowSceneName = Application.loadedLevelName;
    }

    /// <summary>
    /// 次のシーンに遷移
    /// </summary>
    public static void Play()
    {
        
        //ゲームシーンのとき
        if (nowSceneName != "movie")
        {
            //nowSceneName = "movie";
            //クリアか判定
            if (clearFlag)
            {
                //nowSceneName = nowSceneName + "Clear";
                playMovie = nextMovie;
                nextMovie = "";
                nowSceneName = storyFlag ? "movie" : "Menu";
            }
            else
            {
                nextSceneName = "Menu";
                playMovie = nowSceneName + "Bad";
                nowSceneName = "movie";
                nextMovie = "";
            }
        }
        else//ビデオシーンのとき
        {
            nowSceneName = nextSceneName;
        }

        //nextSceneNameに画面遷移
        SceneManager.LoadScene(nowSceneName);
    }
}
