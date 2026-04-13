using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SellScript : MonoBehaviour
{


    public LogicScript logic;
    public PackScript pack;
    public Image sellProgress;
    public float timeToSell = 1.5f; 
    public float saveTime;
    public float multyTime = 1f;
    
    public bool isSelling;
    public float maxBar;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveTime = timeToSell;
        sellProgress.fillAmount = 0f;
        maxBar = 1f;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelling == true)
        {
            if (Input.GetKey(KeyCode.E) == true && pack.numberOfEggs != 0)
            {
                
                timeToSell -= multyTime * Time.deltaTime;
                sellProgress.fillAmount = maxBar - (timeToSell * (1f / saveTime));
                if (timeToSell <= 0)
                {
                    pack.EggSelled();
                    logic.AddMoneyOnSell();
                    logic.AddScore();
                    timeToSell = saveTime;
                }
            }
            else
            {
                sellProgress.fillAmount = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSelling = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSelling = false;
        }
    }

    public void NewMaxSellTime(float newSellTime)
    {
        multyTime = newSellTime;
    }

}
