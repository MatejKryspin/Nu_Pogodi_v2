using System;
using JetBrains.Annotations;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


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
    public List<int> eggValues = new List<int>(); //tady budu uchovavat hodnoty vajec ktere byly sebrany a pak az je prodam tak se z toho arraye bude pricitat k penezum
    public int pos = 0;
    //public int sellpos = 0;

    
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
        if (eggValues.Count == 0)
        {
            pos = 0;
        }
        else
        {
            pos = eggValues.Count - 1;
        }
        if (type == "normal")
        {
            //playerMoney += 3;
            eggValues.Add(3);

        }
        else if (type == "speed")
        {
           //playerMoney += 1; 
           eggValues.Add(1);
        }
        else if (type == "reversed")
        {
            //playerMoney += 10;
            eggValues.Add(10);
        }
        else if (type == "confused")
        {
            //playerMoney += 8;
            eggValues.Add(8);
        }
        //moneyText.text = $"{playerMoney}";

        //udelam aby se uchovala hodnota vajec ktere byly sebrany takze udelam array do ktereho budu psat ty ceny tech vajec a pak az je prodam tak se z toho arraye bude pricitat k penezum
        
    }

    public void AddMoneyOnSell()
    {
        playerMoney += eggValues[0];
        moneyText.text = $"{playerMoney}";
        eggValues.RemoveAt(0); //odstrani prvni prvek z pole a posune vsechny ostatni o jednu pozici dopredu
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
