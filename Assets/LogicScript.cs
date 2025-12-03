using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public SpawnScript spawn;
    public Text scoreText;
    public Text pointsText;
    public Text lifeText;
    public int playerLifes = 3;
    public int currentLifes;
    public int maxQuota = 10; //10 je pro zatim aby priste jsem to mohl zvednout


    public DaySystem days;

    
    public float roundTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLifes = playerLifes;
        lifeText.text = $"{currentLifes}/{playerLifes}";
        scoreText.text = $"{playerScore}/{maxQuota}";
        /*if (dayN == 0)
        {
            maxQuota = 10;  //test
            packSize = 10;
            roundTime = 20;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //pak to dam do elsu kdyz neni shop nebo stop ale tedka to tady nemam
        //roundTime -= 1 * Time.deltaTime;

        if (playerScore >= maxQuota)
        {
            days.CompleteDay();
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
    public void AddPoints(int eggs, int size)
    {
        pointsText.text = $"{eggs}/{size}";
    }
    public void LoseLife()
    {
        if (currentLifes <= 0)
        {
            return;
        }
        else
        {
            currentLifes--;
            lifeText.text = $"{currentLifes}/{playerLifes}";
        }
    }

    public void NewDay()
    {
        playerScore = 0; 
        scoreText.text = $"{playerScore}/{maxQuota}";
        currentLifes = playerLifes;
        lifeText.text = $"{currentLifes}/{playerLifes}";
        spawn.spawnTime = 0;
        spawn.spawnPicked = false;
        
    }
}
