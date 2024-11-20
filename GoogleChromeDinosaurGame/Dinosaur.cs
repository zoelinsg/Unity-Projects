using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    Rigidbody2D rb; //恐龍身上的rigidbody2D
    public float jump; //向上的力
    bool isJumping;  //恐龍是否在跳躍
    public GameManager gm;  //GameManager
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;  //一開始恐龍還沒有跳
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isJumping==false)
        {
            //當按下空白鍵以及沒有在跳躍的狀態,才會往上跳(不能連跳)
            rb.velocity = new Vector2(0, jump);  //向上跳的力
            isJumping = true;  //轉成跳躍狀態
        }
    }


    //調整跳的狀態
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;

        if (collision.gameObject.tag == "Cactus")
        {
            //如果恐龍撞到仙人掌就死掉了,遊戲結束
            gm.GameOver();
        }
        
    }
}
