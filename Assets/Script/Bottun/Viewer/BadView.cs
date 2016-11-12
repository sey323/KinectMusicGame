using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BadView : MonoBehaviour
{

    public Text badView;

    // Update is called once per frame
    void Update()
    {
        if (Remover.badanotate == true)
        {
            StartCoroutine("Bader");
            Remover.badanotate = false;
        }
    }
    IEnumerator Bader()
    {
        badView.text = "Bad...";
        yield return new WaitForSeconds(1.0f);
        badView.text = null;

    }
}
