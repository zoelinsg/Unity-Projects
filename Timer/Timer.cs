using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("目前時間")] public float currentTime;  //現在時間
    [Header("正在計時")] public bool isTiming;  //正在計時

    [Header("間隔秒數")] public float interval; //間隔秒數
    [Header("計時")] public float countTime; //每隔一段時間計時重置
    
    void Start()
    {

    }

    //開始新的計時
    public void StartNewTiming()
    {
        isTiming = true;
        currentTime = 0;
    }

    //暫停
    public void Pause()
    {
        //如果正在計時就暫時計時,如果暫停計時就繼續計時
        isTiming = !isTiming;

    }

    void FixedUpdate()
    {
        CountCurrentTime();
        SlowUpdate();
    }

    void SlowUpdate() 
    {
        if (isTiming)
        {
            countTime += Time.fixedDeltaTime;
            if (countTime > interval)
            {
                //如過經過時間大於間隔,目前時間歸零
                countTime = 0;
                Debug.Log(currentTime);
            }
        }
    }

    //計算目前時間
    void CountCurrentTime() 
    {
        if (isTiming)
        {
            //正在計時
            currentTime += Time.fixedDeltaTime;
        }
    }
}
