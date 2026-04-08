using UnityEngine;

public class PackScript : MonoBehaviour
{
    // Reference na ostatni skripty
    public LogicScript logic;
    public SpawnScript spawn;
    public PlayerScript player;
    
    // Prefab EffectBar a kontejner (ten tvůj EffectPanel s Layout Groupem)
    public GameObject effectBarPrefab;
    public Transform effectContainer;
    
    public int numberOfEggs = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. NORMÁLNÍ VEJCE
        if (collision.gameObject.CompareTag("Egg"))
        {
            HandlePickup(collision.gameObject, "normal", 0, "");
        }
        
        // 2. SPEED VEJCE
        else if (collision.gameObject.CompareTag("SpeedEgg"))
        {
            player.StartSpeedEffect(5f, 10f);
            HandlePickup(collision.gameObject, "speed", 10f, "Speed");
        }
        
        // 3. REVERSED VEJCE
        else if (collision.gameObject.CompareTag("ReversedEgg"))
        {
            player.StartReversedEffect(5f);
            HandlePickup(collision.gameObject, "reversed", 5f, "Reversed");
        }
        
        // 4. CONFUSED VEJCE
        else if (collision.gameObject.CompareTag("ConfusedEgg"))
        {
            spawn.StartConfusedEffect(5f);
            HandlePickup(collision.gameObject, "confused", 5f, "Confused");
        }
    }

    //Smazání vejce, body i spawn UI baru
    private void HandlePickup(GameObject egg, string moneyType, float duration, string effectName)
    {
        Destroy(egg);
        numberOfEggs++;
        logic.AddMoneyOnPickup(moneyType);
        logic.AddPoints(numberOfEggs);

        // Pokud je to efektové vejce (má jméno), spawneme bar přímo do panelu
        if (!string.IsNullOrEmpty(effectName) && effectBarPrefab != null && effectContainer != null) //!string.IsNullOrEmpty(effectName) zajistí, že se bar spawnne jen u efektových vajec
        {
            //Druhý parametr effectContainer zajistí, že se bar zařadí do Layoutu
            GameObject effectBar = Instantiate(effectBarPrefab, effectContainer);
            
            StatusEffectUI effectUI = effectBar.GetComponent<StatusEffectUI>();
            if (effectUI != null)
            {
                Debug.Log("Effect Started");
                effectUI.StartUIEffectDuration(duration, effectName);
            }
        }
    }

    // Po prodeji vejce se počet vajec sníží o 1 a aktualizují se body
    public void EggSelled()
    {
        if (numberOfEggs > 0)
        {
            numberOfEggs--;
            logic.AddPoints(numberOfEggs);
        }
    }
}