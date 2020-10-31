using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeInfoPanel : MonoBehaviour
{

    public InfoPanelController infoPanel;

    public void OnClick()
    {
        infoPanel.closeInformationPanel();
    }
}
