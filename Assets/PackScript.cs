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
