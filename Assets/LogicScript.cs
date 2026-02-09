using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
 

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public SpawnScript spawn;
    public DayTransition dTrans;
    public Text scoreText;
    public Text pointsText;
    public Text moneyText;
    public int playerMoney = 0;
    public int maxQuota = 10; //10 je pro zatim aby priste jsem to mohl zvednout
    public bool dayIsEnding = false;


    public DaySystem days;

    public GameObject UI;

    
    public float roundTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText.text = $"{playerMoney}";
        scoreText.text = $"{playerScore}/{maxQuota}";
        UI.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //pak to dam do elsu kdyz neni shop nebo stop ale tedka to tady nemam
        //roundTime -= 1 * Time.deltaTime;

        if (playerScore >= maxQuota && !dayIsEnding)
        {
            
            dTrans.StartDayTransition();
            dayIsEnding = true;

        }

    }

    public void AddScore()
    {
        if (playerScore >= maxQuota)
        {
            return;
        }
        else
        {
            playerScore++;
            scoreText.text = $"{playerScore}/{maxQuota}"; 
        }
    }
    public void  AddPoints(int eggs)
    {
        pointsText.text = $"{eggs}";
    }
    public void LoseMoneyOnDrop()
    {
        playerMoney -= 5;
        if (playerMoney < 0)
        {
            playerMoney = 0;
        }
        moneyText.text = $"{playerMoney}";
    }

    public void AddMoneyOnPickup(string type)
    {
        if (type == "normal")
        {
            playerMoney += 3;
        }
        if (type == "speed")
        {
           playerMoney += 1; 
        }
        if (type == "reversed")
        {
            playerMoney += 10;
        }
        if (type == "confused")
        {
            playerMoney += 8;
        }
        
    }

    public void NewDay()
    {
        playerScore = 0; 
        scoreText.text = $"{playerScore}/{maxQuota}";
        
        dayIsEnding = false;
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
