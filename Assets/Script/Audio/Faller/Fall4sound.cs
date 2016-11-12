using UnityEngine;
using System.Collections;

public class Fall4sound : MonoBehaviour
{

    private Vector3 m_pos;

    // Use this for initialization
    void Start()
    {
        m_pos = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = m_pos;
        m_pos.z += 0.7f;

    }
}
