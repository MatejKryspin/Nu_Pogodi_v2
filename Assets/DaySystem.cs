using System;
using UnityEngine;

[System.Serializable] //zajisti ze v editoru je to videt jako seznam
public class DayData //data pro kazdy den neboli objekt a jeho atributy
{
    public int quota; //deni quota
    public int packSize; //velikost sacku
    public int time; //round time
}

public class DaySystem : MonoBehaviour
{


    public LogicScript logic; 
    public PackScript pack;
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
        pack.packSize = day.packSize;   //ten den se prenastavil na jeden den z toho listu dnii a tim padem musim prenastavit jednotlive hodnoty ve hre tady
        logic.roundTime = day.time;

        //jelikoz vlastne zapinam dalsi hru tak musim taky vyrestartovat score
        pack.numberOfEggs = 0; 
        logic.AddPoints(pack.numberOfEggs, pack.packSize);
        logic.NewDay(); 


    }
    public void CompleteDay()
    {
        currentDay += 1; 

        if (currentDay >= days.Length)
        {
            Debug.Log("Byl dosazen konec hry!");
            return;
        }
        
        StartDay(currentDay);

    }
}
