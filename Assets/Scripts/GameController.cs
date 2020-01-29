using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text finalText;
    public int winAmount;
    public MoneyManager money;
    public HeatController heat; 
    public GameObject mainPanel;
    public TimeController time;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void lose()
    {
        time.stopTimer();
        mainPanel.SetActive(false);
        finalText.color = Color.red;
        finalText.text = "They found you! Game over! Time:" + time.getTime().ToString();
        finalText.gameObject.SetActive(true);
    }

    private void win()
    {
        time.stopTimer();
        mainPanel.SetActive(false);
        finalText.text = "Hooray! You won! Time:" + time.getTime().ToString();
        finalText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (heat.GetHeat() >= 100)
        {
            lose();
        }

        if (money.GetMoney() >= winAmount)
        {
            win();
        }
    }
}
