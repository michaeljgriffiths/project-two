using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TerminalController : MonoBehaviour
{

    public Text commandText;
    public Text terminalText;
    private char pipe;
    public bool typing;
    public float typingSpeed;
    public float typingRandomness;
    private string motd;
    private string prefix;
    private DateTime currentTime;


    // Start is called before the first frame update
    void Start()
    {
        commandText.text = "";
        setMOTD();
        prefix = "<color=#E056FD>prince@kali:~$</color> ";
        commandText.text = commandText.text + "\n" + prefix;
        typing = false;
        pipe = '_';
        StartCoroutine(BlinkText());
        


    }

    public void typeTextInCommandLine(string text)
    {

        Debug.Log("tpying");
        //We farm off to a coroutine which will simulate a user typing.
        StartCoroutine(typeTheText(text, done =>
        {
            if (done !=null)
            {
                if (done)
                {
                    Debug.Log("Typing finished");
                    insertStdOutToTerminal(text);
                }
                else
                {
                    Debug.Log("An error has occured with the Coroutine typeTheText");
                }
            }
        }
        ));
        
        
        
    }

    //function to blink the text
    public IEnumerator BlinkText()
    {
        //blink it forever. Except for when we are typing
        while (!typing)
        {
            //set the Text's text to blank
            commandText.text = commandText.text + pipe.ToString();
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            commandText.text = commandText.text.Replace(pipe.ToString(), "");
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator typeTheText(string textToType, System.Action<bool> done)
    {
        typing = true;
        Debug.Log(textToType.Length);
        int textLength = textToType.Length;
        int i = 0;

        while (i < textLength +1)
        {
            
            {
                commandText.text = prefix + textToType.Substring(0, i);              
                yield return new WaitForSeconds(UnityEngine.Random.Range(typingSpeed, typingSpeed * 3));
            }
            i++;
        }
        // When finished Clear the textbox so it is nice and clean for the next command.
        commandText.text = "\n" + prefix;
        Debug.Log("Stop Typing");
        typing = false;
        StartCoroutine(BlinkText());
        done(true);
    }

    private void setMOTD()
    {
        currentTime = System.DateTime.Now;
        motd = "------------------------\nOS: Kali Linux x86_64\nCurrent Time: " + currentTime.ToString() + "\nMessages: 0\n------------------------";
        terminalText.text = motd;
    }
  

    private void insertStdOutToTerminal(string textToOutput)
    {
        // Add a newline
        terminalText.text = terminalText.text + "\n";
        //Add the inserted value
        terminalText.text = terminalText.text + prefix + textToOutput;

    }

    public bool getTypingStatus()
    {
        //Debug.Log("Getting typing status");
        //Debug.Log(typing.ToString());
        return typing;
    }
}

