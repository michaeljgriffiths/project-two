using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TypeText : MonoBehaviour
{
    public TerminalController tc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void sendTextToTerminal()
    {
        Debug.Log("sending text");
        tc.typeTextInCommandLine("ps -ef | grep java");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
