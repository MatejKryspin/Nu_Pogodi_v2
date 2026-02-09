using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

    public GameObject egg;
    public GameObject warning;
    public GameObject[] specialEggs;


    public float spawnTime = 0f;
    public float maxSpawn = 2.5f;
    public bool canSpawn = true;
    public bool spawnPicked = false;
    public bool confused = false;
    public int confusedIndex;
   
   
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
        if (canSpawn)
        {
            spawnTime += 1f * Time.deltaTime;
            if (spawnTime > 0.5f * maxSpawn && spawnPicked == false)
            {
                index = Random.Range(0, spawnPoints.Length);        //vybere nahodnou pozici pole mezi 0 az delkou pole
                if (confused)
                {
                    if (index % 2 > 0)
                    {
                        confusedIndex = index + 1;
                        
                    }
                    else if (index % 2 == 0)
                    {
                        confusedIndex = index - 1;
                        
                    }
                    WarningSpawn(confusedIndex);
                    spawnPicked = true;
                }
                if (!confused)
                {
                    WarningSpawn(index);
                    spawnPicked = true;
                }
            }

            
            
            if (spawnTime > maxSpawn)
            {
                EggSpawn(index);
                spawnTime = 0f;
                spawnPicked = false;
                
            }
        }
        else
        {
            spawnTime = 0f;
            spawnPicked = false;
        }
        

    }

    [ContextMenu("SpawnEgg")]
    private void EggSpawn(int index)
    {
        Transform spawnpoint = spawnPoints[index];          //zase: spawnpoint prevezme informace ktere ma spawnPoints[index] a dale je muzeme pouzit
        Debug.Log("Spawning egg at: " + index);
        GameObject eggToSpawn = PickEgg();
        Instantiate(eggToSpawn, spawnpoint.position, spawnpoint.rotation);
    }
    private void WarningSpawn(int index){
        Transform spawnpoint = spawnPoints[index];          //zase: spawnpoint prevezme informace ktere ma spawnPoints[index] a dale je muzeme pouzit
        Debug.Log("Spawning warning at: " + index);
        Instantiate(warning, spawnpoint.position, spawnpoint.rotation);
    }


    public void SetNewMaxSpawnTime(float newMaxSpawn)
    {
        maxSpawn = newMaxSpawn;
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
    public void StartSpawning()
    {
        canSpawn = true;
    }



    GameObject PickEgg()
    {
        float roll = Random.Range(0f, 100f); 
        if (roll < 70f)
        {
            return egg;
        }
       
        int index = Random.Range(0, specialEggs.Length);
        return specialEggs[index];
        
    }

    public void StartConfusedEffect(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ConfusedEffectRoutine(duration));
           
    }
    
    IEnumerator ConfusedEffectRoutine(float duration)
    {
        confused = true;
        yield return new WaitForSeconds(duration);
        confused = false;
        
    }
}
