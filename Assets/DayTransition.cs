using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayTransition : MonoBehaviour
{
    public GameObject dayPanel;
    public Text countdownText;

    public DaySystem daySystem;
    public SpawnScript spawn;
    public PlayerScript player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartDayTransition()
    {
        StartCoroutine(DayTransitionCycle());
    }

    IEnumerator DayTransitionCycle()
    {
        Time.timeScale = 0f;
        spawn.StopSpawning();
        player.TeleportToSpawn();
        dayPanel.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        dayPanel.SetActive(false);

        Time.timeScale = 1f;

        daySystem.CompleteDay();
        spawn.StartSpawning();

    }
}
