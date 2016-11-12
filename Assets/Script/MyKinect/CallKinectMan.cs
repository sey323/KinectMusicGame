using UnityEngine;
using System.Collections;

public class CallKinectMan : MonoBehaviour {

    private int player;
    public SkeletonWrapper sw;//put on kinect prefab

    public GameObject[] kinectGundan;
    //private bool[] kinectsFlag;

    // Use this for initialization
    void Start () {
        kinectGundan = GameObject.FindGameObjectsWithTag("KinectMan");
        //kinectGundan = GetComponentsInChildren<GameObject>();
        for( int i = 0; i< kinectGundan.Length; i++)
        {
           kinectGundan[i].GetComponent<KinectPointController>().player = i;
        }
        //sw.GetComponents<SkeletonWrapper>();
    }

    // Update is called once per frame
    void Update () {
        for (int player = 0; player < sw.trackedPlayers.Length; player++)
        {
            //print(player +","+ sw.trackedPlayers[player]);
            if (sw.trackedPlayers[player] != -1 && !kinectGundan[player].activeInHierarchy)
            {
                kinectGundan[player].SetActive(true);
            }
            else if (sw.trackedPlayers[player] == -1 && kinectGundan[player].activeInHierarchy)
            {
                kinectGundan[player].SetActive(false);
            }
        }
    }
}
