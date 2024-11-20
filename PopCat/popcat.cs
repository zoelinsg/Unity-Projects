using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject popcatClose;  //關嘴巴的貓
    public GameObject popcatOpen;   //開嘴巴的貓
    public TextMeshProUGUI ScoreText;  //分數

    int ScoreCount;  //分數數值

    void Update()
    {
        //用滑鼠控制
        if (Input.GetMouseButtonDown(0))
        {
            //按下滑鼠時,顯示開嘴巴的貓
            popcatClose.SetActive(false);
            popcatOpen.SetActive(true);

            GetComponent<AudioSource>().Play();  //播放啵啵聲
            ScoreCount++;  //分數數值加一
            ScoreText.text = ScoreCount.ToString();  //分數數值轉成文字形態展示
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //放開滑鼠時,顯示閉嘴巴的貓
            popcatClose.SetActive(true);
            popcatOpen.SetActive(false);
        }
    }
}
