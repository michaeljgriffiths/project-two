using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelInterface : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 open;
    private Vector3 closed;
    public bool panelOpened;
    private bool openingPanel;
    private bool closingPanel;
    private float lerpValue;
    private float smoothingValue;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        //rectTransform.anchoredPosition = closed;
        closed = new Vector3(0, -350, 0);
        open = new Vector3(0, 390, 0);
        panelOpened = false;
        openingPanel = false;
        closingPanel = false;
        lerpValue = 0f;
        smoothingValue = 0.03f;
}

    public void togglePanel()
    {

        if (panelOpened)
        {
            closePanel();
        }
        else
        {
            openPanel();
        }
    }


    private void openPanel()
    {
        openingPanel = true;
    }

    public void closePanel()
    {
        closingPanel = true;
    }

    private void Update()
    {
        if (openingPanel)
        {
            if (lerpValue >=1)
            {
                openingPanel = false;
                lerpValue = 0f;
                panelOpened = true;
            }

            else
            {
                lerpValue += smoothingValue;
                rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.position, open, lerpValue);
            }

        }

        if (closingPanel)
        {
            if (lerpValue >= 1)
            {
                closingPanel = false;
                lerpValue = 0f;
                panelOpened = false;
            }

            else
            {
                lerpValue += smoothingValue;
                rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.position, closed, lerpValue);
            }
        }
    }
}