using System;
using System.Reflection.Emit;
using UnityEngine;

public class PackScript : MonoBehaviour
{

    // Reference na ostatni skripty pro spousteni efektu a updatovani UI
    public LogicScript logic;
    public SpawnScript spawn;
    public PlayerScript player;
    
    // Prefab EffectBar - zvizualni efekt ktery se spawne kdyz hrac sebere specialni vejce
    public GameObject effectBarPrefab;
    
    // Pocet vejcek v inventari hrace
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
        // Kontrola normalního vejce
        if (collision.gameObject.CompareTag("Egg"))
        {
            numberOfEggs++;
            logic.AddMoneyOnPickup("normal");
            logic.AddPoints(numberOfEggs);
            Destroy(collision.gameObject);
        }
        // Kontrola speed efektu vejce
        else if (collision.gameObject.CompareTag("SpeedEgg"))
        {
            Debug.Log("Hrac sebral speed vajce");
            
            // Spusti efekt na playeru - zvysuje rychlost o 5 na dobu 10 sekund
            player.StartSpeedEffect(5f, 10f); //boost amount, duration
            
            // Spawn EffectBar prefabu pro vizualni feedback
            if (effectBarPrefab != null)
            {
                Debug.Log("Spawning EffectBar pro Speed efekt");
                // Vytvori kopii EffectBar prefabu
                GameObject effectBar = Instantiate(effectBarPrefab);
                
                // Najdi canvas, aby UI patřilo na spravnou vrstvu
                Canvas canvas = FindFirstObjectByType<Canvas>();
                if (canvas != null)
                {
                    effectBar.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    Debug.LogWarning("Nebyl nalezen Canvas ve scene. EffectBar zustane nekde samostatne.");
                }
                
                // Ziska kompontu StatusEffectUI z prefabu aby se mohl zobrazit timer
                StatusEffectUI effectUI = effectBar.GetComponent<StatusEffectUI>();
                if (effectUI != null)
                {
                    // Spusti UI efekt s duraci 10 sekund a jmenem "Speed"
                    effectUI.StartUIEffectDuration(10f, "Speed");
                }
            }
            else
            {
                Debug.LogError("effectBarPrefab neni prirazen! Jdi na PackScript v editoru a priradi EffectBar.prefab do pole effectBarPrefab");
            }
            
            Destroy(collision.gameObject);
            numberOfEggs++;
            logic.AddMoneyOnPickup("speed");
            logic.AddPoints(numberOfEggs);

        }
        // Kontrola reversed efektu vejce
        else if (collision.gameObject.CompareTag("ReversedEgg"))
        {
            
            // Spusti reversed efekt - prevrace ovladani hrace na dobu 5 sekund
            player.StartReversedEffect(5f); //duration
            
            // Spawn EffectBar prefabu pro vizualni feedback
            if (effectBarPrefab != null)
            {
                Debug.Log("Spawning EffectBar pro Reversed efekt");
                GameObject effectBar = Instantiate(effectBarPrefab);
                Canvas canvas = FindFirstObjectByType<Canvas>();
                if (canvas != null)
                {
                    effectBar.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    Debug.LogWarning("Nebyl nalezen Canvas ve scene. EffectBar zustane nekde samostatne.");
                }
                StatusEffectUI effectUI = effectBar.GetComponent<StatusEffectUI>();
                if (effectUI != null)
                {
                    effectUI.StartUIEffectDuration(5f, "Reversed");
                }
            }
            else
            {
                Debug.LogError("effectBarPrefab neni prirazen! Jdi na PackScript v editoru a priradi EffectBar.prefab do pole effectBarPrefab");
            }
            
            Destroy(collision.gameObject);
            numberOfEggs++;
            logic.AddMoneyOnPickup("reversed");
            logic.AddPoints(numberOfEggs);

        }
        // Kontrola confused efektu vejce
        else if (collision.gameObject.CompareTag("ConfusedEgg"))
        {
            
            // Spusti confused efekt - vytvori random spawn pozice na dobu 5 sekund
            spawn.StartConfusedEffect(5f); //duration
            
            // Spawn EffectBar prefabu pro vizualni feedback
            if (effectBarPrefab != null)
            {
                Debug.Log("Spawning EffectBar pro Confused efekt");
                GameObject effectBar = Instantiate(effectBarPrefab);
                Canvas canvas = FindFirstObjectByType<Canvas>();
                if (canvas != null)
                {
                    effectBar.transform.SetParent(canvas.transform, false);
                }
                else
                {
                    Debug.LogWarning("Nebyl nalezen Canvas ve scene. EffectBar zustane nekde samostatne.");
                }
                StatusEffectUI effectUI = effectBar.GetComponent<StatusEffectUI>();
                if (effectUI != null)
                {
                    effectUI.StartUIEffectDuration(5f, "Confused");
                }
            }
            else
            {
                Debug.LogError("effectBarPrefab neni prirazen! Jdi na PackScript v editoru a priradi EffectBar.prefab do pole effectBarPrefab");
            }
            
            Destroy(collision.gameObject);
            numberOfEggs++;
            logic.AddMoneyOnPickup("confused");
            logic.AddPoints(numberOfEggs);

        }
    }
    public void EggSelled()
    {
        // Smaž jedno vejce z inventare a aktualizuj pocet na UI
        if (numberOfEggs > 0)
        {
            numberOfEggs--;
            logic.AddPoints(numberOfEggs);
        }
    }

    
}
