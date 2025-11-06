using UnityEngine;

public class PackScript : MonoBehaviour
{

    public bool Grabed = false;

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
            Grabed = true;
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
