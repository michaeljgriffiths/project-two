using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickController : MonoBehaviour, IPointerClickHandler
{
    public MoneyManager moneyManager;
    public ValueController valueController;
    public GameObject particle;
    ParticleSystem particleSystem;
    RectTransform particleRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        print(eventData);
        Instantiate(particle);
        moneyManager.AddMoney(valueController.getClickValue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
