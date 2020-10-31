using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour


{
    public InfoPanelController infoPanel;
    public string infoHeader;
    public string infoBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onClick()
    {
        infoPanel.openInformationPanel(infoHeader, infoBody);
    }

}
