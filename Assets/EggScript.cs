using UnityEngine;

public class EggScript : MonoBehaviour
{

    public LogicScript logic;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            logic.LoseMoneyOnDrop();
            Destroy(gameObject);
        }
    }

    
}
