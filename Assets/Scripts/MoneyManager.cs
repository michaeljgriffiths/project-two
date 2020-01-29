using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    // Variable Declaration
    Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = gameObject.GetComponent<Text>();
    }

    private int Money()
    {
        return int.Parse(moneyText.text);
    }

    public int GetMoney()
    {
        return Money();
    }

    public void AddMoney(int amount)
    {
        int newAmount = Money() + amount;
        moneyText.text = newAmount.ToString();
    }

    public void SubtractMoney(int amount)
    {
        int newAmount = Money() - amount;
        moneyText.text = newAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
