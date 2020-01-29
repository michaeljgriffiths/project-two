using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    Text timeText;
    bool keepTime;
    double currentTime;

    // Start is called before the first frame update
    void Start()
    {
        timeText = gameObject.GetComponent<Text>();
        keepTime = true;
    }

    public string getTime()
    {
        return timeText.text;
    }

    public void stopTimer()
    {
        keepTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepTime)
        {
            currentTime = System.Math.Round(Time.time, 2);
            timeText.text = currentTime.ToString();
        }
        
    }
}
