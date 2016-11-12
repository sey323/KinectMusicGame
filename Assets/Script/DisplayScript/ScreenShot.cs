using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenShot : MonoBehaviour
{
    private string nowTime;
    private bool isRunning = false;

    //画質調整
    private float max;
    private int scale;

    void Start()
    {
        max = Mathf.Max(Screen.width, Screen.height);
        scale = Mathf.RoundToInt(2048 / max);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) )
        {
            StartCoroutine("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator screenshot()
    {
 
        if (isRunning) yield break;

        isRunning = true;
        System.DateTime thisTime = System.DateTime.Now;

        nowTime = thisTime.ToString("yyyyMMdd_hhmmss");

        //Application.CaptureScreenshot(Application.dataPath + "/Picture/"+  nowTime + "_Capture.png" , scale);
        Application.CaptureScreenshot(Application.streamingAssetsPath + "/ " + nowTime + "_Capture.png", scale);


        print(Application.dataPath + "/Picture/"+ nowTime  + "Screen.png" );
        yield return new WaitForSeconds(0.5f);

        isRunning = false;

    }
}
