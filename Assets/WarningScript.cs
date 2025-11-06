using UnityEngine;

public class WarningScript : MonoBehaviour
{

    public SpawnScript spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnScript>();
        float lifeTime = spawn.maxSpawn * 0.4f;

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
