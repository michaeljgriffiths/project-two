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
    public string itemName;
    public Text haveText;
    public int quantityOwned;


    // Start is called before the first frame update
    void Start()
    {
        quantityOwned = 0;
        shopItem = gameObject.GetComponent<Button>();
        shopItem.interactable = false;
        costText.text = "Costs $" + cost.ToString();
        haveText.text = "Have: " + quantityOwned.ToString(); 

    }

    public void onClick()
    {
        if (money.GetMoney() >0)
        {
            if (money.GetMoney() - cost >= 0)
            {
                heat.ReduceHeat(reduceHeatBy);
                money.SubtractMoney(cost);
                quantityOwned = quantityOwned + 1;
                haveText.text = "Have: " + quantityOwned.ToString();
            }

        }

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
