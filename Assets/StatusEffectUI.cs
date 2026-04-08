using UnityEngine;
using UnityEngine.UI;

public class StatusEffectUI : MonoBehaviour
{
    
    // Obrazek s cooldownem - fillAmount ukazuje jak dlouho trva efekt
    public Image cooldownImage;
    
    // Text ktery ma vypisovat nazev efektu a zbyvajici cas
    public Text timerText;
    
    public float duration;
    public bool effectStarts = false;
    public float timeLeft;
    
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (effectStarts == true)
        {
            
            
            timeLeft -= Time.deltaTime;
            cooldownImage.fillAmount = timeLeft / duration;
            if (timeLeft <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartUIEffectDuration(float effectDuration, string effectType)
    {
        // Zkontroluj jestli je timerText prirazen v editoru
        if (timerText == null)
        {
            Debug.LogError("StatusEffectUI: timerText neni prirazen!");
            return;
        }
        
        // Zkontroluj jestli je cooldownImage prirazen v editoru
        if (cooldownImage == null)
        {
            Debug.LogError("StatusEffectUI: cooldownImage neni prirazen!");
            return;
        }
        
        // Nastavi text na nazev efektu
        timerText.text = $"{effectType}";
        timeLeft = effectDuration;
        duration = effectDuration;
        effectStarts = true;
    }
}
