using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PrayMovie : MonoBehaviour {

    //再生するファイル名
    public string _movieFile;//流す動画
    //public string nextScene;//次のゲームシーン

    private string fomat;

    public MovieTexture movieFiles; 

    void Awake()
    {
        fomat = GameController.fomat;
        _movieFile = GameController.playMovie + fomat;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(moviePlay(_movieFile));
    }


    // Update is called once per frame
    void Update()
    {
        try
        {
            //動画スキップと動画終了判定
            if (Input.GetKey("space") || !movieFiles.isPlaying || Gesture.LoveAndPiece)
            {
                Gesture.HandCrossing = false;
                GameController.Play();
            }
        }
        catch (UnassignedReferenceException e)
        {
            //エラーじゃない！
        }
    }

    /// <summary>
    /// 動画再生用
    /// </summary>
    /// <param name="movieFile"></param>
    /// <returns></returns>
    private IEnumerator moviePlay(string movieFile)
    {
        //動画名の取得
        string movieTexturePath = Application.streamingAssetsPath + "/" + movieFile;
        string url = "file://" + movieTexturePath;
        WWW movie = new WWW(url);

        while (!movie.isDone)
        {
            yield return null;
        }

       movieFiles = movie.movie;
 
        while (!movieFiles.isReadyToPlay)
        {
            yield return null;
        }

        //動画をレンダリングするオブジェクトの指定
        var renderer = GetComponent<GUITexture>();
        renderer.texture = movieFiles;

        movieFiles.Play();

        //オーディオを使用する場合はこの部分を有効に
        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = movieFiles.audioClip;
        //audioSource.loop = true;
        audioSource.Play();
    }
}