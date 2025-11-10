using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{

    public PackScript ps;
    public int playerScore;
    public Text scoreText;
    public int maxQuota = 10; //10 je pro zatim aby priste jsem to mohl zvednout
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //scoreText.text = $"{playerScore.ToString()}/{maxQuota.ToString()}"
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(){
        playerScore += 1;
        scoreText.text = $"{playerScore.ToString()}/{maxQuota.ToString()}";
    }
}
