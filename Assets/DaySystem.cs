using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable] //zajisti ze v editoru je to videt jako seznam
public class DayData //data pro kazdy den neboli objekt a jeho atributy
{
    public int quota; //deni quota
    public int minMoney; //minimalni penize pro start dne
    public int time; //round time
    public float spawnInterval; //spawn vajec
    public float sellInterval; //rychlost prodeje
}

public class DaySystem : MonoBehaviour
{


    public LogicScript logic; 
    public DayTransition dTrans;
    public SpawnScript spawner;
    public PackScript pack;
    public SellScript sell;
    public DayData[] days; //jakoby tabulka kde jeden radek je jeden den s hodnotama z daydata takze jeden radek je "day" s atributama z DayData.
    public int currentDay = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDay(currentDay);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDay(int dayIndex)
    {
        DayData day = days[dayIndex]; //jeden den s atributami z DayData se nastavi na hodnoty vybrane z tabulky days s nejakym indexem

        logic.maxQuota = day.quota; 
        logic.roundTime = day.time; //stale nefunguje a je to na rozsireni

        

        //jelikoz vlastne zapinam dalsi hru tak musim taky vyrestartovat score
        pack.numberOfEggs = 0; 
        logic.AddPoints(pack.numberOfEggs);
        logic.NewDay(); 
        spawner.SetNewMaxSpawnTime(day.spawnInterval);
        sell.NewMaxSellTime(day.sellInterval);
        


    }

    public void CompleteDay()
    {
        DayData endingday = days[currentDay];
        
        logic.playerMoney -= endingday.minMoney;


        if (currentDay >= days.Length)
        {
            Debug.Log("Byl dosazen konec hry!");
            
            if (logic.playerMoney <= 0)
            {
                Debug.Log("Hrac prohral!");
                SceneManager.LoadSceneAsync(2);
                return;
            }
            else
            {
                Debug.Log("Hrac vyhral!");
                SceneManager.LoadSceneAsync(3);
                return;
            }
        }
        
        currentDay += 1; 
        StartDay(currentDay);

    }

    
}
