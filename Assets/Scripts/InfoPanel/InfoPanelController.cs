using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour
{
    public GameObject headerText;
    public GameObject bodyText;
    private Text headerTextContent;
    private Text bodyTextContent;
    private RectTransform rectTransform;
    private Vector3 panelClosedPosition;
    private Vector3 panelOpenedPosition;

    // Start is called before the first frame update
    void Start()
    {
        headerTextContent = headerText.GetComponent<Text>();
        bodyTextContent = bodyText.GetComponent<Text>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        //rectTransform.anchoredPosition = closed;
        panelClosedPosition = new Vector3(-735, 0, 0);
        panelOpenedPosition = new Vector3(0, 0, 0);
    }

    private void setInfoText(string header, string body)
    {
        // The unity editor escapes <br> and \n so we need to emove the escaped chars
        header = header.Replace("<br>", "\n");
        body = body.Replace("<br>", "\n");
        header = header.Replace("\\n", "\n");
        header = header.Replace("\\n", "\n");

        headerTextContent.text = header;
        bodyTextContent.text = body;
    }

    public void closeInformationPanel()
    {
        rectTransform.anchoredPosition = panelClosedPosition;

    }
    public void openInformationPanel(string header, string body)
    {
        setInfoText(header, body);
        rectTransform.anchoredPosition = panelOpenedPosition;
    }


}
