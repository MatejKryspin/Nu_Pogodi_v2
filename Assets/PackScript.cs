using System.Reflection.Emit;
using UnityEngine;

public class PackScript : MonoBehaviour
{

    public bool Grabed = false;
    public LogicScript logic;
    public int packSize;
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
            Grabed = true;      //je to pro eggscript aby vedel kdy ma vymazat objekt
            logic.AddPoints();   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg")){
            Grabed = false;
        }
    }

    public bool IsGrabed()
    {
        return Grabed;
    }
}
