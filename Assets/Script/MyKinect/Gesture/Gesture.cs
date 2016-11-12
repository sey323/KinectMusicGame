using UnityEngine;
using System.Collections;

/// <summary>
/// 人のモーションの様子
/// </summary>
public class Gesture :MonoBehaviour
{
    public static bool gesture_flag;                //ジェスチャーが認識されているか
    /// <summary>
    /// 「bool ジェスチャー名」のポーズがとられているか(true,false)
    /// </summary>
    public static bool LoveAndPiece;                //両手を頭の上で組んでいる
    public static bool Meshia;                      //両手を頭の上に挙げている様子
    public static bool OverHeadHandSclap;           //頭の上での拍手

    public static bool RightHandRising;
    public static bool RightHandWaving;             //右手を横方向に振っている
    public static bool RightHandWavingHardly;       //右手を横方向に激しく振っている
    public static bool RightHandPushing;            //右手を縦方向に振っている
    public static bool RightHandPushingHardly;      //右手を縦方向に激しく振っている

    public static bool LeftHandRising;
    public static bool LeftHandWaving;
    public static bool LeftHandWavingHardly;
    public static bool LeftHandPushing;
    public static bool LeftHandPushingHardly;

    public static bool DownHand;                    //手で押さえつける動作
    public static bool Angel;                       //両手を広げているさま
    public static bool HandClap;                    //頭より下の位置で拍手をしている
    public static bool HandCrossing;                //頭より下の位置で手を交差している

    public static Vector3 RightHandPosition;        //右手の平の位置(Vecter:x,y,z)
    public static Vector3 LeftHandPosition;         //左手の平の位置(Vecter:x,y,z)

}
