using UnityEngine;
using System.Collections;

public class MaskScript : MonoBehaviour
{
    Texture2D color;
    Texture2D depth;
    public Texture2D back;
    public Material Mat;
    DisplayDepthScraps ddepth;
    DisplayColorScraps dcolor;


    void Awake()
    {
        ddepth = this.GetComponent<DisplayDepthScraps>();
        dcolor = this.gameObject.GetComponent<DisplayColorScraps>();
    }
    // Use this for initialization
    void Start()
    {
        Mat.SetTexture("_MainTex", color);
        Mat.SetTexture("_BackTex", back);
        Mat.SetTexture("_MaskTex", depth);

    }

    // Update is called once per frame
    void Update()
    {
        color = dcolor.tex;
        depth = ddepth.tex;

        Mat.SetTexture("_MainTex", color);
        Mat.SetTexture("_BackTex", back);
        Mat.SetTexture("_MaskTex", depth);
    }

}