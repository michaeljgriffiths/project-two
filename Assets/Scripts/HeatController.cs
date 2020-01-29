using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatController : MonoBehaviour
{
    float heatValue;
    Text heatText;
    // Start is called before the first frame update
    void Start()
    {
        heatText = gameObject.GetComponent<Text>();
        heatText.text = "0%";
    }


    private float Heat()
    {
        return heatValue;
        ;
    }

    public float GetHeat()
    {
        return Heat();
    }

    public void AddHeat(float amount)
    {
        float newAmount = Heat() + amount;
        heatValue = newAmount;
        heatText.text = newAmount.ToString() + "%"; 
    }

    public void ReduceHeat(float amount)
    {
        float newAmount = Heat() - amount;
        heatValue = newAmount;
        heatText.text = newAmount.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


