using System.Reflection.Emit;
using UnityEngine;

public class PackScript : MonoBehaviour
{

    
    public LogicScript logic;
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
            logic.AddMoneyOnPickup();
            logic.AddPoints(numberOfEggs);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SpeedEgg"))
        {
            PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            player.StartSpeedEffect(2f, 10f);
            numberOfEggs++;
            logic.AddMoneyOnPickup();
            logic.AddPoints(numberOfEggs);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ReversedEgg"))
        {
            PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            player.StartReversedEffect(10f);
            numberOfEggs++;
            logic.AddMoneyOnPickup();
            logic.AddPoints(numberOfEggs);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ConfusedEgg"))
        {
            PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            //player.StartConfusedEffect(); to ze se ukaze vykricnik na druhe strane nez se spawnuje vajicko
            numberOfEggs++;
            logic.AddMoneyOnPickup();
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
