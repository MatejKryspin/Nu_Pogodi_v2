using System.Reflection.Emit;
using UnityEngine;

public class PackScript : MonoBehaviour
{

    
    public LogicScript logic;
    public SpawnScript spawn;
    public PlayerScript player;
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
            
            player.StartSpeedEffect(5f, 10f); //boost amount, duration
            numberOfEggs++;
            logic.AddMoneyOnPickup("speed");
            logic.AddPoints(numberOfEggs);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ReversedEgg"))
        {
            
            player.StartReversedEffect(5f); //duration
            numberOfEggs++;
            logic.AddMoneyOnPickup("reversed");
            logic.AddPoints(numberOfEggs);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ConfusedEgg"))
        {
            
            spawn.StartConfusedEffect(5f); //duration
            numberOfEggs++;
            logic.AddMoneyOnPickup("confused");
            logic.AddPoints(numberOfEggs);

            Destroy(collision.gameObject);
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
