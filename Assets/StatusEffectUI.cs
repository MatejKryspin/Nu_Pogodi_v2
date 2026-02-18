using UnityEngine;
using UnityEngine.UI;

public class StatusEffectUI : MonoBehaviour
{
    

    public Image cooldownImage;
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
        timerText.text = $"{effectType}";
        timeLeft = effectDuration;
        duration = effectDuration;
        effectStarts = true;
    }
}
