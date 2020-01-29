using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemButton : MonoBehaviour
{
    public int cost;
    public float reduceHeatBy;
    public Text costText;
    public MoneyManager money;
    public HeatController heat;
    Button shopItem;

    // Start is called before the first frame update
    void Start()
    {
        shopItem = gameObject.GetComponent<Button>();
        shopItem.interactable = false;
        costText.text = "Costs $" + cost.ToString();
    }

    public void onClick()
    {
        heat.ReduceHeat(reduceHeatBy);
        money.SubtractMoney(cost);
    }


    // Update is called once per frame
    void Update()
    {
        if (money.GetMoney() >= cost)
        {
            shopItem.interactable = true;
        }
    }
}
