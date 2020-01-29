using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelController : MonoBehaviour
{
    public int controlledPanelNumber;
    private GameObject controlledPanel;
    public List<GameObject> bottomPanels = new List<GameObject>();
    private panelInterface panelInterface;
    private panelInterface panelInterfaces;
    private double currentTime;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        controlledPanel = bottomPanels[controlledPanelNumber];
    }

    public void activatePanel()
    {
        closeAllPanels();
        panelInterface = controlledPanel.GetComponent<panelInterface>();

        Debug.Log(getTimeToString() +  "panelController calling TogglePanel");

        panelInterface.togglePanel();
    }

    private void closeAllPanels()
    {
        count = 0;
        Debug.Log(getTimeToString() + "panelController closing all panels");
        foreach (GameObject bottomPanel in bottomPanels)
        {
            if (count != controlledPanelNumber)
            {
                panelInterfaces = bottomPanel.GetComponent<panelInterface>();
                panelInterfaces.closePanel();

            }
            count++;

        }
    }

    private string getTimeToString()
    {
        return System.Math.Round(Time.time, 2).ToString();
    }
}
