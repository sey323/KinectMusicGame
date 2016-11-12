using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GreatView : MonoBehaviour
{
    //的 
    private GameObject obj1;
    private GameObject obj2;
    private GameObject obj3;
    private GameObject obj4;
    private GameObject obj5;
    private GameObject obj6;
    private GameObject obj7;
    private GameObject obj8;


    public Text greatView;
    public Text goodView;

    private GreatHantei greatA;
    private GreatHantei greatS;
    private GreatHantei greatD;
    private GreatHantei greatF;
    private GreatHantei greatG;
    private GreatHantei greatH;
    private GreatHantei greatJ;
    private GreatHantei greatK;

    void Start()
    {
        //ボタンの初期
        obj1 = GameObject.FindGameObjectWithTag("obj1");
        obj2 = GameObject.FindGameObjectWithTag("obj2");
        obj3 = GameObject.FindGameObjectWithTag("obj3");
        obj4 = GameObject.FindGameObjectWithTag("obj4");
        obj5 = GameObject.FindGameObjectWithTag("obj5");
        obj6 = GameObject.FindGameObjectWithTag("obj6");
        obj7 = GameObject.FindGameObjectWithTag("obj7");
        obj8 = GameObject.FindGameObjectWithTag("obj8");

        greatA = obj1.GetComponent<GreatHantei>();
        greatS = obj2.GetComponent<GreatHantei>();
        greatD = obj3.GetComponent<GreatHantei>();
        greatF = obj4.GetComponent<GreatHantei>();
        greatG = obj5.GetComponent<GreatHantei>();
        greatH = obj6.GetComponent<GreatHantei>();
        greatJ = obj7.GetComponent<GreatHantei>();
        greatK = obj8.GetComponent<GreatHantei>();
    }

    // Update is called once per frame
    void Update()
    {

        if (greatA.isGreat())
        {
            StartCoroutine("Greater");
            greatA.initialize();
            //GreatA1.greatanotate = false;
        }

        if (greatS.isGreat())
        {
            StartCoroutine("Greater");
            greatS.initialize();
            //GreatS1.greatanotate = false;

            //print("SSSGJGJ");
        }
        if (greatD.isGreat())
        {
            StartCoroutine("Greater");
            greatD.initialize();
            //GreatD1.greatanotate = false;

            //print("DDDGJGJ");
        }
        if (greatF.isGreat())
        {
            StartCoroutine("Greater");
            greatF.initialize();
            //GreatF1.greatanotate = false;

            //print("FFFGJGJ");
        }
        if (greatG.isGreat())
        {
            StartCoroutine("Greater");
            greatG.initialize();
            //GreatG1.greatanotate = false;

            //print("GGGGJGJ");
        }
        if (greatH.isGreat())
        {
            StartCoroutine("Greater");
            greatH.initialize();
            //GreatH1.greatanotate = false;

            //print("HHHGJGJ");
        }
        if (greatJ.isGreat())
        {
            StartCoroutine("Greater");
            greatJ.initialize();
            //GreatJ1.greatanotate = false;

            //print("JJJGJGJ");
        }
        if (greatK.isGreat())
        {
            StartCoroutine("Greater");
            greatK.initialize();
            //GreatK1.greatanotate = false;

            //print("KKKGJGJ"); 
        }

        //Goodチェッカー
        if (greatA.isGood())
        {
            StartCoroutine("Gootter");
            greatA.initialize();
            //GreatA1.greatanotate = false;
        }

        if (greatS.isGood())
        {
            StartCoroutine("Gootter");
            greatS.initialize();
            //GreatS1.greatanotate = false;

            //print("SSSGJGJ");
        }
        if (greatD.isGood())
        {
            StartCoroutine("Gootter");
            greatD.initialize();
            //GreatD1.greatanotate = false;

            //print("DDDGJGJ");
        }
        if (greatF.isGood())
        {
            StartCoroutine("Gootter");
            greatF.initialize();
            //GreatF1.greatanotate = false;

            //print("FFFGJGJ");
        }
        if (greatG.isGood())
        {
            StartCoroutine("Gootter");
            greatG.initialize();
            //GreatG1.greatanotate = false;

            //print("GGGGJGJ");
        }
        if (greatH.isGood())
        {
            StartCoroutine("Gootter");
            greatH.initialize();
            //GreatH1.greatanotate = false;

            //print("HHHGJGJ");
        }
        if (greatJ.isGood())
        {
            StartCoroutine("Gootter");
            greatJ.initialize();
            //GreatJ1.greatanotate = false;

            //print("JJJGJGJ");
        }
        if (greatK.isGood())
        {
            StartCoroutine("Gootter");
            greatK.initialize();
            //GreatK1.greatanotate = false;

            //print("KKKGJGJ"); 
        }
    }

    IEnumerator Greater()
    {
        greatView.text = "Great!";
        yield return new WaitForSeconds(1.0f);
        greatView.text = null;

    }

    IEnumerator Gootter()
    {
        goodView.text = "Good!";
        yield return new WaitForSeconds(1.0f);
        goodView.text = null;
    }
}
