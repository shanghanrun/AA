using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI textGoal;

    public int goal;

    [SerializeField]
    private GameObject btnRetry;

    [SerializeField]
    private Color green;
    [SerializeField]
    private Color red;

    public bool isGameOver = false;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    void Start()
    {
        textGoal.SetText(goal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseGoal(){
        goal--;
        textGoal.SetText(goal.ToString());
        if (goal <= 0){
            SetGameOver(true);  // 성공했을 경우 true전달
        }
    }

    public void SetGameOver(bool success){
        if(isGameOver == false){  // 항상 게임오버를 true로 만들기
            isGameOver = true;

            Camera.main.backgroundColor = success ? green : red;
            Invoke("ShowRetryButton", 1f);
        }
    }

    void ShowRetryButton(){
        btnRetry.SetActive(true);
    }

    public void Retry(){
        SceneManager.LoadScene("SampleScene");
    }


}
