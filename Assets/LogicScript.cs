using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{

    public PackScript ps;
    public int playerScore;
    public Text scoreText;
    public Text pointsText;
    public int maxQuota; //10 je pro zatim aby priste jsem to mohl zvednout
    
    public int packSize;
    public int eggPoints;

    public int dayN;
    public float roundTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (dayN == 0)
        {
            maxQuota = 10;  //test
            packSize = 10;
            roundTime = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (maxQuota == playerScore)
        {

        }
        //pak to dam do elsu kdyz neni shop nebo stop ale tedka to tady nemam
        roundTime -= 1 * Time.deltaTime;

    }

    public void AddScore()
    {
        playerScore += 1;
        scoreText.text = $"{playerScore.ToString()}/{maxQuota.ToString()}";
    }
    public void AddPoints()
    {
        eggPoints += 1;
        pointsText.text = $"{eggPoints.ToString()}/{packSize.ToString()}";
    }
}
