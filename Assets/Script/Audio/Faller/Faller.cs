using UnityEngine;
using System.Collections;

public class Faller : MonoBehaviour {

    private Transform target;
    private float times;
    //private float startDistance;
    public float perSize;

    private Vector3 firstVec;
    private Vector3 firstSize;
    public Vector3 size;
    private Vector3 vec;

    //移動にかかる時間
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {

        //target = GameObject.FindGameObjectWithTag("obj").transform;

        //距離と速度
        times = transform.position.z;
        firstVec = target.position - transform.position;
        vec = firstVec / times;

        //ボタンサイズ
        firstSize.z = 0;
        firstSize = target.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //距離と速度
        transform.position += vec * speed;

        //ボタンサイズ
        perSize = 1 - ((target.position - transform.position).magnitude / firstVec.magnitude);
        perSize = perSize / 2;
        size = firstSize * (1 + perSize);
        target.localScale = size;
        /*
		transform.localPosition = m_pos;
		m_pos.z -= 0.9f;
        m_pos.y += 0.6f;
        m_pos.x += 0.15f;
        */
    }

    /// <summary>
    /// 消えるときの処理
    /// </summary>
    void OnDestroy()
    {
        target.localScale = GameObject.FindGameObjectWithTag("obj1").GetComponent<GreatHantei>().defaultSize;
    }
}
