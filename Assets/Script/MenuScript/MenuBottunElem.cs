using UnityEngine;
using System.Collections;

public class MenuBottunElem : MonoBehaviour {

    public int count;
    private bool isRunning;

    private Vector3 defaultSize;

	// Use this for initialization
	void Start () {
        count = 0;
        defaultSize = this.transform.localScale;
	}


    void Update()
    {
        if(count != 0)
        {
            this.transform.localScale = defaultSize + defaultSize * count / 10;
        }
    }


    /// <summary>
    /// キネクトとの接触判定（時間）
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "KinectHand")
        {
            StartCoroutine("Counter");
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
            count = 0;
        }
    }

    IEnumerator Counter()
    {
        if (isRunning) {yield break; }
        isRunning = true;

        count++;

        yield return new WaitForSeconds(1.0f);
        isRunning = false;
    }
}
