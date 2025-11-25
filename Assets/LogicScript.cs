using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public Text pointsText;
    public int maxQuota = 10; //10 je pro zatim aby priste jsem to mohl zvednout


    public int dayN;
    public Array[] days;
    public float roundTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        

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
}
