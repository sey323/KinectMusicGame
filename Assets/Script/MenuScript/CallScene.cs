using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CallScene : MonoBehaviour {

    //的 
    private GameObject easy;
    private GameObject middle;
    private GameObject hard;
    private GameObject story;
    private GameObject tutorial;

    private MenuBottunElem easyBtn;
    private MenuBottunElem middleBtn;
    private MenuBottunElem hardBtn;
    private MenuBottunElem storyBtn;
    private MenuBottunElem tutorialBtn;

    private int waitTime = 4;

    // Use this for initialization
    void Start () {
        GameController.totalScore = 0;
        GameController.storyFlag = false;

        //ボタンの初期
        easy = GameObject.Find("Easy");
        middle = GameObject.Find("Middle");
        hard = GameObject.Find("Hard");
        story = GameObject.Find("Story");
        tutorial = GameObject.Find("Tutorial");

        //MenuBottunの初期化
        easyBtn = easy.GetComponent<MenuBottunElem>();
        middleBtn = middle.GetComponent<MenuBottunElem>();
        hardBtn = hard.GetComponent<MenuBottunElem>();
        storyBtn = story.GetComponent<MenuBottunElem>();
        tutorialBtn = tutorial.GetComponent<MenuBottunElem>();
    }
	
	// Update is called once per frame
	void Update () {
        if ( easyBtn.count > waitTime || Input.GetKeyDown(KeyCode.A))//Easyモード
        {
            GameController.storyFlag = false;
            GameController.playMovie = ("EasyStart");
            GameController.nextSceneName = ("GameModeEasy");
            SceneManager.LoadScene("movie");
        }
        if (middleBtn.count > waitTime || Input.GetKeyDown(KeyCode.S))//Middleモード
        {
            GameController.storyFlag = false;
            GameController.playMovie = ("MiddleStart");
            GameController.nextSceneName = ("GameModeMiddle");
            SceneManager.LoadScene("movie");
        }
        if (hardBtn.count > waitTime || Input.GetKeyDown(KeyCode.D))//Hardモード
        {
            GameController.storyFlag = false;
            GameController.playMovie = ("HardStart");
            GameController.nextSceneName = ("GameModeHard");
            SceneManager.LoadScene("movie");
        }
        if (tutorialBtn.count > waitTime || Input.GetKeyDown(KeyCode.F))//Tutorial
        {
            GameController.storyFlag = false;
            GameController.nextSceneName = "Menu";
            SceneManager.LoadScene("Tutorial");
        }
        if (storyBtn.count > waitTime || Input.GetKeyDown(KeyCode.G))//Storyモード
        {
            GameController.storyFlag = true;
            GameController.playMovie = ("EasyStart");
            GameController.nextSceneName = ("GameModeEasy");
            SceneManager.LoadScene("movie");
        }
    }
}
