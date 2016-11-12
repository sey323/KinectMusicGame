using UnityEngine;
using System.Collections;


public class Sound : MonoBehaviour
{

    public AudioSource sound01;
    
    bool Flag = false;

    // Use this for initialization
    void Start()
    {
        //AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 =GetComponent<AudioSource>();
        //sound02 = audioSources[1];
        //sound03 = audioSources[2];
    }


    public void OnTriggerEnter(Collider other)
    {

        if (!Flag)
        {
            sound01.PlayOneShot(sound01.clip);
            Destroy(other.gameObject);
            Flag = true;
        }
    }

}
