using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class KinectNetSync : NetworkBehaviour {

    static KinectNetSync Current_;

    [SyncVar]
    private  bool LoveAndPiece= false;                //両手を頭の上で組んでいる
    [SyncVar]
    private  bool Meshia= false;                      //両手を頭の上に挙げている様子
    [SyncVar]
    private  bool OverHeadHandSclap= false;           //頭の上での拍手

    [SyncVar]
    private  bool RightHandRising= false;
    [SyncVar]
    private  bool RightHandWaving= false;             //右手を横方向に振っている
    [SyncVar]
    private  bool RightHandWavingHardly= false;       //右手を横方向に激しく振っている
    [SyncVar]
    private  bool RightHandPushing= false;            //右手を縦方向に振っている
    [SyncVar]
    private  bool RightHandPushingHardly= false;      //右手を縦方向に激しく振っている

    [SyncVar]
    private  bool LeftHandRising= false;
    [SyncVar]
    private  bool LeftHandWaving= false;
    [SyncVar]
    private  bool LeftHandWavingHardly= false;
    [SyncVar]
    private  bool LeftHandPushing= false;
    [SyncVar]
    private  bool LeftHandPushingHardly= false;

    [SyncVar]
    private  bool DownHand= false;                    //手で押さえつける動作
    [SyncVar]
    private  bool Angel= false;                       //両手を広げているさま
    [SyncVar]
    private  bool HandClap= false;                    //頭より下の位置で拍手をしている
    [SyncVar]
    private  bool HandCrossing= false;                //頭より下の位置で手を交差している

    public static bool ServServLoveAndPeice { get { return Current_.LoveAndPiece; } }
    public static bool ServMeshia { get { return Current_.Meshia; } }
    public static bool ServOverHeadHandSclap { get { return Current_.OverHeadHandSclap; } }

    public static bool ServRightHandRising { get { return Current_.RightHandRising; } }
    public static bool ServRightHandWaving { get { return Current_.RightHandWaving; } }             //右手を横方向に振っている
    public static bool ServRightHandWavingHardly { get { return Current_.RightHandWavingHardly; } }        //右手を横方向に激しく振っている
    public static bool ServRightHandPushing { get{ return Current_.RightHandPushing; } }            //右手を縦方向に振っている
    public static bool ServRightHandPushingHardly { get { return Current_.RightHandPushingHardly; } }     //右手を縦方向に激しく振っている

    public static bool ServLeftHandRising {get { return Current_.LeftHandRising; } }
    public static bool ServLeftHandWaving {get { return Current_.LeftHandWaving; } }
    public static bool ServLeftHandWavingHardly {get { return Current_.LeftHandWavingHardly; } }
    public static bool ServLeftHandPushing{get{return Current_.LeftHandPushing; }}
    public static bool ServLeftHandPushingHardly{get{return Current_.LeftHandPushingHardly; }}

    public static bool ServDownHand{get{return Current_.DownHand; }}                    //手で押さえつける動作
    public static bool ServAngel{get{return Current_.Angel; }}                       //両手を広げているさま
    public static bool ServHandClap{get{return Current_.HandClap; }}                    //頭より下の位置で拍手をしている
    public static bool ServHandCrossing { get{ return Current_.HandCrossing; } }

    // Use this for initialization
    void Start () {
        Current_=this;	
	}
	
	// Update is called once per frame
    [ServerCallback]
	void Update () {
    LoveAndPiece=Gesture.LoveAndPiece;                //両手を頭の上で組んでいる
    Meshia=Gesture.Meshia;                      //両手を頭の上に挙げている様子
    OverHeadHandSclap=Gesture.OverHeadHandSclap;           //頭の上での拍手

    RightHandRising=Gesture.RightHandRising;
    RightHandWaving=Gesture.RightHandWaving;             //右手を横方向に振っている
    RightHandWavingHardly=Gesture.RightHandWavingHardly;       //右手を横方向に激しく振っている
    RightHandPushing=Gesture.RightHandPushing;            //右手を縦方向に振っている
    RightHandPushingHardly=Gesture.RightHandPushingHardly;      //右手を縦方向に激しく振っている

    LeftHandRising=Gesture.LeftHandRising;
    LeftHandWaving=Gesture.LeftHandWaving;
    LeftHandWavingHardly=Gesture.LeftHandWavingHardly;
    LeftHandPushing=Gesture.LeftHandPushing;
    LeftHandPushingHardly=Gesture.LeftHandPushingHardly;

    DownHand=Gesture.DownHand;                    //手で押さえつける動作
    Angel=Gesture.Angel;                       //両手を広げているさま
    HandClap=Gesture.HandClap;                    //頭より下の位置で拍手をしている
    HandCrossing=Gesture.HandCrossing;                //頭より下の位置で手を交差している

}
}
