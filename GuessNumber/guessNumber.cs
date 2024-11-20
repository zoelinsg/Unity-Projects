using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;  //跟場景管理有關

public class gamemanager : MonoBehaviour
{
    public InputField playerAnswerUI;  //玩家輸入的答案
    public int playerAnswer;  //解析過後的玩家答案
    public int correctAnswer;  //正確答案
    public Text hintMessage;  //提示訊息
    public Button restartButton;  //重新開始的按鈕
    void Start()
    {
        NewQuestion();  //產生一個新題目
    }

    void UpdateHintMessage(string message) 
    {
        //更新提示訊息
        hintMessage.text = message;
    }

    void NewQuestion() 
    {
        //產生一個新題目
        UpdateHintMessage("請輸入0~99之間的數字");  //遊戲開始秀出提示訊息
        correctAnswer = Random.Range(0, 100); //隨機產生一個亂數0~99
        restartButton.gameObject.SetActive(false);  //重新開始的按鈕在遊戲一開始先不出現
    }

    bool CanInputNumber() 
    {
        //判斷輸入的是否為數字
        return int.TryParse(playerAnswerUI.text, out playerAnswer);  //試著將玩家輸入的轉換為數字,同時輸出是否轉換成功的結果
    }

    public void ComparePlayerAnswer() 
    {
        //比對遊戲玩家輸入的答案
        //playerAnswer = int.Parse(playerAnswerUI.text);  //將玩家輸入的答案轉換成整數型態
        if (!CanInputNumber()) 
        {
            //如果無法轉換成數字
            UpdateHintMessage("只能輸入數字喔!");  //更新提示訊息
            return;
        }

        if (playerAnswer == correctAnswer)
        {
            UpdateHintMessage("恭喜你答對了!");  //遊戲玩家猜中正確數字,更新提示訊息
            restartButton.gameObject.SetActive(true);  //答對後重新開始的按鈕又出現
        }
        if (playerAnswer > correctAnswer)
        {
            UpdateHintMessage("答案要再小一點!");  //遊戲玩家猜的數字比正確數字大,更新提示訊息
        }
        if (playerAnswer < correctAnswer)
        {
            UpdateHintMessage("答案要再大一點!");  //遊戲玩家猜的數字比正確數字小,更新提示訊息
        }
        focusPlayerAnswerUI();  //當輸入完答案時,可自動聚焦在輸入欄位以達到連續輸入答案
    }

    void focusPlayerAnswerUI() 
    {
        //讓系統自動聚焦在輸入介面上,以達到可以連續輸入的效果
        playerAnswerUI.ActivateInputField();
    }
     public void ClearHintMessage() 
    {
        UpdateHintMessage(""); //當輸入答案有變動時,清空提示訊息
    }

    public void ReloadScene() 
    {
        //重新讀取場景
        Scene scene = SceneManager.GetActiveScene();  //目前讀取的場景
        SceneManager.LoadScene(scene.name);  //又再讀取目前的場景
    }
    void Update()
    {
        
    }
}
