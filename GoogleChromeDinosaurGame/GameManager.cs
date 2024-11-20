using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cactus;  //仙人掌
    public GameObject cactusSpawnPosition;  //仙人掌生成位置
    public float spawnTime;  //仙人掌生成時間
    float timer;  //計時器
    public GameObject GameOverScene;  //遊戲結束的場景

    void Start()
    {
        Time.timeScale = 1;  //以一倍速玩這遊戲
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;  //計時器

        if (timer >= spawnTime)
        {
            //每隔1.5秒(可自己調整)生成一株新的仙人掌
            //當計時器的時間超過仙人掌生成時間,就會冒出新的仙人掌
            Instantiate(cactus,cactusSpawnPosition.transform);  //生成仙人掌
            timer = 0;  //計時器歸零,重新計時
        }
    }

    public void GameOver() 
    {
        //遊戲結束
        Time.timeScale = 0;  //把遊戲暫停
        GameOverScene.SetActive(true);  //遊戲結束的畫面加載進來
    }

    public void Restart() 
    {
        //遊戲重新開始
        SceneManager.LoadScene("lv1");  //重新加載遊戲場景
    }
}
