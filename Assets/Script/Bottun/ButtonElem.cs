using UnityEngine;
using System.Collections;

public class ButtonElem : MonoBehaviour {

    //  float[] lllist = { 20, 20 };
    // 位置座標
    private Vector3 position;

    public float latitude;//緯度
    public float longitude;//経度
    public float radius;
    public float scalex, scaley, scalez;

    private float x, y, z;
    private float radius_1;
    private float phi;
    private float theta;

    //ボタンクリック時効果音
    public AudioSource effecter;
    public AudioClip effect;
    private bool effectFlag = true;
    
    //ボタン入力判定
    private bool EnterFlag = false ;

    void Start()
    {
        effecter = GetComponent<AudioSource>();
        effecter.clip = effect;
    }
    
    /// <summary>
    /// update
    /// </summary>
    void Update()
    {
        //haiti();
        EnterFlag = false;
    }

    /// <summary>
    /// セッター
    /// </summary>
    /// <param name="Getlat"></param>
    /// <param name="Getlong"></param>
    /// <param name="Getradius"></param>
    public void haitiSet(float Getlong, float Getlat, float Getradius)
    {
        longitude = Getlong;
        latitude = Getlat;
        radius = Getradius;
    }

    /// <summary>
    /// ボタンの配置
    /// </summary>
    public void haiti( )
    {
        //経度緯度から位置を算出
        //仰角
        phi = latitude * Mathf.PI / 180;
        //方位学
        theta = (longitude - 180) * Mathf.PI / 180;

        x = -(radius) * Mathf.Cos(phi) * Mathf.Cos(theta);
        y = (radius) * Mathf.Sin(phi);
        z = (radius) * Mathf.Cos(phi) * Mathf.Sin(theta);


        transform.position = new Vector3(x, y, z);
        transform.LookAt(Vector3.zero);

        //print("checker");
    }

    /// <summary>
    /// ゲッター
    /// </summary>
    /// <returns></returns>
    public bool isEnter()
    {
        //print(EnterFlag);
        return EnterFlag;
    }

    /// <summary>
    /// キネクトとの接触判定（接触始まり）
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        StartCoroutine("onEffect", col);
    }

    /// <summary>
    /// キネクトとの接触判定（接触始まり）
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "KinectHand")
        {
            EnterFlag = true;
            //Debug.Log("Get " + tag);
        }
    }

    /// <summary>
    /// キネクトとの接触判定（接触終わり）
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "KinectHand")
        {
            EnterFlag = false;
            //Debug.Log("Exit " + tag);
        }
    }

    /// <summary>
    /// エフェクト鳴らすラグ
    /// </summary>
    /// <param name="col"></param>
    IEnumerator onEffect(Collider col)
    {
        if (col.gameObject.tag == "KinectHand" && effectFlag)
        {
            effectFlag = false;
            effecter.Play();
        }

        yield return new WaitForSeconds(0.7f);
        effectFlag = true;

    }
}
