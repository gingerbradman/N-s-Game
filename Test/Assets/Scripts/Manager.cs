using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject Eagle;
    public int birdTimer;

    public Player player;
    private int playerHealth;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI birdText;
    public TextMeshProUGUI nathanText;
    public TextMeshProUGUI rebeccaText;

    public int birdCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummonEagle(birdTimer));
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.stats.curHealth;
        healthText.SetText("Health: " + playerHealth);

        birdText.SetText("Bird Count: " + birdCount);

        if (birdCount == 23)
        {
            nathanText.SetText("Happy 23rd Birthday Nathan!");
            rebeccaText.SetText("Rebecca will give you your gift after Quarantine!");
        }
        
    }

    IEnumerator SummonEagle(int sec)
    {
        while (birdCount < 23)
        {
            yield return new WaitForSeconds(sec);
            Instantiate(Eagle);
            
        }
    }
}
