using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using UnityEngine;
using Kinect;


public class GetMotion : MonoBehaviour
{


    public SkeletonWrapper sw;

    public int player;
    //  public BoneMask Mask = BoneMask.All;

    private GameObject[] _bones; //internal handle for the bones of the model

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (player == -1)
            return;
        //update all of the bones positions
        if (sw.pollSkeleton())
        {
            //Both Hand Rising pettern
            if (RisingHand(11) && RisingHand(7))
            {
                if (CrossHitCheck(5, 7, 10, 12))
                {
                    print("Love And Piece");
                }
                else
                {
                    print("MESHIA");
                }
            }

            //Right Hand Motion pettern
            else if (RisingHand(11))
            {
                if (WavingHand(10, 0.5, 1.2))
                {
                    print("RightHand is waving");
                }
                else if (WavingHand(10, 1.3, 100))
                {
                    print("RightHand is big waving ");
                }
                else if (PushingHand(10, 0.5, 1.2))
                {
                    print("RightHand is pushing");
                }
                else if (PushingHand(10, 1.3, 100))
                {
                    print("RightHand is pushing hardly");
                }
                else
                {
                    print("Right hund is Rising");
                }
            }
            //Left Hand Motion pettern
            else if (RisingHand(7))
            {
                if (WavingHand(6, 0.5, 1.2))
                {
                    print("LeftHand is waving");
                }
                else if (WavingHand(6, 1.3, 100))
                {
                    print("LeftHand is big waving ");
                }
                else if (PushingHand(6, 0.5, 1.2))
                {
                    print("LeftHand is pushing");
                }
                else if (PushingHand(6, 1.3, 100))
                {
                    print("LeftHand is pushing hardly");
                }
                else
                {
                    print("Left hund is Rising");
                }
            }

            //
            else if (CrossHitCheck(6, 7, 10, 11))
            {
                print("HandClap");
            }
            else if (CrossHitCheck(5, 6, 9, 10))
            {
                print("Hands are crossing");
            }
        }
    }



    /// <summary>
    /// 手を挙げているかの判定
    /// </summary>
    /// <param name="boneCode"></param>
    /// <returns></returns>
    private bool RisingHand(int boneCode)
    {
        if ((sw.bonePos[player, boneCode].y > sw.bonePos[player, 3].y))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 手を振っているかの判定
    /// </summary>
    /// <param name="boneCode"></param>
    /// <returns></returns>
    private bool WavingHand(int boneCode, double under, double over)
    {
        if ((sw.boneVel[player, boneCode].x >= under && sw.boneVel[player, boneCode].x <= over)
            || (sw.boneVel[player, boneCode].x * -1 <= under && sw.boneVel[player, boneCode].x * -1 >= over))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Z軸に手を振っているかの判定
    /// </summary>
    /// <param name="boneCode"></param>
    /// <returns></returns>
    private bool PushingHand(int boneCode, double under, double over)
    {
        if ((sw.boneVel[player, boneCode].z >= under && sw.boneVel[player, boneCode].z <= over)
             || (sw.boneVel[player, boneCode].z * -1 <= under && sw.boneVel[player, boneCode].z * -1 >= over))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 交差判定
    /// </summary>
    /// <param name="boneCodeA1"></param>
    /// <param name="boneCodeA2"></param>
    /// <param name="boneCodeB1"></param>
    /// <param name="boneCodeB2"></param>
    /// <returns></returns>
    private bool CrossHitCheck(int boneCodeA1, int boneCodeA2, int boneCodeB1, int boneCodeB2)
    {
        //ax * by - ay * bx
        double v1 = (sw.bonePos[player, boneCodeA2].x - sw.bonePos[player, boneCodeA1].x) * (sw.bonePos[player, boneCodeB1].y - sw.bonePos[player, boneCodeA1].y) - (sw.bonePos[player, boneCodeA2].y - sw.bonePos[player, boneCodeA1].y) * (sw.bonePos[player, boneCodeB1].x - sw.bonePos[player, boneCodeA1].x);
        double v2 = (sw.bonePos[player, boneCodeA2].x - sw.bonePos[player, boneCodeA1].x) * (sw.bonePos[player, boneCodeB2].y - sw.bonePos[player, boneCodeA1].y) - (sw.bonePos[player, boneCodeA2].y - sw.bonePos[player, boneCodeA1].y) * (sw.bonePos[player, boneCodeB2].x - sw.bonePos[player, boneCodeA1].x);
        double m1 = (sw.bonePos[player, boneCodeB2].x - sw.bonePos[player, boneCodeB1].x) * (sw.bonePos[player, boneCodeA1].y - sw.bonePos[player, boneCodeB1].y) - (sw.bonePos[player, boneCodeB2].y - sw.bonePos[player, boneCodeB1].y) * (sw.bonePos[player, boneCodeA1].x - sw.bonePos[player, boneCodeB1].x);
        double m2 = (sw.bonePos[player, boneCodeB2].x - sw.bonePos[player, boneCodeB1].x) * (sw.bonePos[player, boneCodeA2].y - sw.bonePos[player, boneCodeB1].y) - (sw.bonePos[player, boneCodeB2].y - sw.bonePos[player, boneCodeB1].y) * (sw.bonePos[player, boneCodeA2].x - sw.bonePos[player, boneCodeB1].x);

        if ((v1 * v2 <= 0) && (m1 * m2 <= 0))
        {
            return true;
        }
        return false;
    }
}

