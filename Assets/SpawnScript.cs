using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnScript : MonoBehaviour
{

    public GameObject egg;
    public GameObject warning;
    public float spawnTime = 0f;
    public float maxSpawn = 10f;
    private bool spawnPicked = false;
   
    public int index;
    public Transform[] spawnPoints;
    public Transform[] warningPoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            warningPoints[i] = spawnPoints[i];
            Vector3 pos = warningPoints[i].position;        //potrebuju jakoby vytvorit kopii toho, ty kopii zmenit x a pak to aplikovat na ten celek. 
            pos.x += 1f;
            warningPoints[i].position = pos;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime + 1f * Time.deltaTime;
        if (spawnTime > 0.5f * maxSpawn && spawnPicked == false)
        {
            index = UnityEngine.Random.Range(0, spawnPoints.Length);        //vybere nahodnou pozici pole mezi 0 az delkou pole
            WarningSpawn(index);
            spawnPicked = true;
        }

        

        if (spawnTime > maxSpawn)
        {
            EggSpawn(index);
            spawnTime = 0f;
            spawnPicked = false;
            
        }

    }

    [ContextMenu("SpawnEgg")]
    private void EggSpawn(int index)
    {
        Transform spawnpoint = spawnPoints[index];          //zase: spawnpoint prevezme informace ktere ma spawnPoints[index] a dale je muzeme pouzit
        Debug.Log("Spawning egg at: " + index);
        Instantiate(egg, spawnpoint.position, spawnpoint.rotation);
    }
    private void WarningSpawn(int index){
        Transform spawnpoint = spawnPoints[index];          //zase: spawnpoint prevezme informace ktere ma spawnPoints[index] a dale je muzeme pouzit
        Debug.Log("Spawning warning at: " + index);
        Instantiate(warning, spawnpoint.position, spawnpoint.rotation);
    }

}
