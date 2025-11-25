using System.Reflection.Emit;
using UnityEngine;

public class PackScript : MonoBehaviour
{

    
    public LogicScript logic;
    public int packSize = 10;
    public int numberOfEggs = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic.AddPoints(numberOfEggs, packSize);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            if (numberOfEggs >= packSize)
            {
                return;
            }
            else
            {
                numberOfEggs++;
                logic.AddPoints(numberOfEggs, packSize);
                Destroy(collision.gameObject);
            }  
        }
    }
    public void EggSelled()
    {
        if (numberOfEggs <= 0)
        {
            return;
        }
        else
        {
        numberOfEggs--;
        logic.AddPoints(numberOfEggs, packSize);   
        }
    }
}
