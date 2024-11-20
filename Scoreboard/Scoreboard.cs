using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Text HpText;  //文字類型的(生命值)

    public float hp;  //生命值

    void Start()
    {
        DisplayHP();  //遊戲一開始就更新生命值
    }

    void Update()
    {
        
    }

    public void Sleep() 
    {
        //睡覺時,生命值增加
        hp += 10;
        DisplayHP();  //更新生命值
    }

    public void DisplayHP() 
    {
        //顯示生命值
        HpText.text = hp.ToString("#");  //將數字類型的生命值轉成文字類型的顯示
        //加#自動去掉小數位後,不顯示小數點後的數字
        //實際上生命值還是有小數點
    }

    public void BeAttacked()
    {
        //被怪物攻擊,生命值會減少
        hp -= 10.6f;
        DisplayHP();  //更新生命值
    }
}
