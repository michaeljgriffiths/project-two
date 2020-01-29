﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour
{

    public Text commandText;
    public Text terminalText;
    private char pipe;
    private bool typing;
    public float typingSpeed;
    public float typingRandomness;


    // Start is called before the first frame update
    void Start()
    {
        commandText.text = "LOLqdsadasdasdads";
        typing = false;
        pipe = '_';
        StartCoroutine(BlinkText());

    }

    public void typeTextInCommandLine(string text)
    {
        Debug.Log("tpying");
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
        //blink it forever. You can set a terminating condition depending upon your requirement
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
                commandText.text = textToType.Substring(0, i);
                Debug.Log(textToType.Substring(0, i));
                
                yield return new WaitForSeconds(Random.Range(typingSpeed, typingSpeed * 3));
            }
            i++;
        }
        Debug.Log("Stop Typing");
        typing = false;
        done(true);
    }
  

    public void insertStdOutToTerminal(string textToOutput)
    {
        // Add a newline
        terminalText.text = terminalText.text + '\n';
        //Add the inserted value
        terminalText.text = terminalText.text + textToOutput;

    }
}
