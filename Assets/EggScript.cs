using UnityEngine;

public class EggScript : MonoBehaviour
{

    public PackScript pack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pack = GameObject.FindGameObjectWithTag("Pack").GetComponent<PackScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Catch();
    }
    
    public void Catch()
    {
        if (pack.IsGrabed() == true)
        {
            Destroy(gameObject);
        }
    }
}
