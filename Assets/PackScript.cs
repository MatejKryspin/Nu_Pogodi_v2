using System;
using System.Reflection.Emit;
using UnityEngine;

public class PackScript : MonoBehaviour
{

    
    public LogicScript logic;
    public SpawnScript spawn;
    public PlayerScript player;
    public StatusEffectUI statusUI;
    public int numberOfEggs = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            numberOfEggs++;
            logic.AddMoneyOnPickup("normal");
            logic.AddPoints(numberOfEggs);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SpeedEgg"))
        {
            Debug.Log("Hrac sebral speed vajce");
            player.StartSpeedEffect(5f, 10f); //boost amount, duration
            statusUI.StartUIEffectDuration(10f, "Speed"); //duration, name
            Destroy(collision.gameObject);
            numberOfEggs++;
            logic.AddMoneyOnPickup("speed");
            logic.AddPoints(numberOfEggs);

        }
        else if (collision.gameObject.CompareTag("ReversedEgg"))
        {
            
            player.StartReversedEffect(5f); //duration
            statusUI.StartUIEffectDuration(5f, "Reversed"); //duration, name
            Destroy(collision.gameObject);
            numberOfEggs++;
            logic.AddMoneyOnPickup("reversed");
            logic.AddPoints(numberOfEggs);

        }
        else if (collision.gameObject.CompareTag("ConfusedEgg"))
        {
            
            spawn.StartConfusedEffect(5f); //duration
            statusUI.StartUIEffectDuration(5f, "Confused"); //duration, name
            Destroy(collision.gameObject);
            numberOfEggs++;
            logic.AddMoneyOnPickup("confused");
            logic.AddPoints(numberOfEggs);

        }
    }
    public void EggSelled()
    {
        if (numberOfEggs > 0)
        {
            numberOfEggs--;
            logic.AddPoints(numberOfEggs);
        }
    }

    
}
