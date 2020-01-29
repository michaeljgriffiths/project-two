using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public int value;
    public int unlockAmount;
    private bool unlocked;
    public MoneyManager money;
    public Text amountTextComponent;
    public float heatChance;
    public HeatController heat;
    public float heatPenalty;
    Button button;
    public Text heatDescription;
    

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.interactable = false;
        updateButtonText();
        heatDescription.text = heatChance.ToString() + "% chance of increasing heat by " + heatPenalty.ToString();
    }

    public void onclick()
    {
        if (unlocked)
        {
            checkForHeat();
            money.AddMoney(value);
        }
    }

    private void checkForHeat()
    {
        float heatPotential = Random.Range(0, 100);
        if (heatPotential < heatChance)
        {
            heat.AddHeat(heatPenalty);
        }
    }

    private void updateButtonText()
    {
        amountTextComponent.text = "$ " + value.ToString();
    }

    private void checkForUnlock()
    {
        if (money.GetMoney() >= unlockAmount)
        {
            unlocked = true;
            button.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForUnlock();
    }
}
