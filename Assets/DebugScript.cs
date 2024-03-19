using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugScript : MonoBehaviour
{
    public bool ActivateDebug;
    public bool Debug1;
    public bool Debug2;
    public bool Debug3;

    public bool Debug1_1;

    public GameObject DebugHelpUI;


    void OnNewBrickInOrder (InputValue value)
    {
        if(Debug1 == false)
        {
            Debug1 = true;
        }
        else
        {
            Debug1 = false;
        }

    }
    void OnNewBrickInOrderMinus (InputValue value)
    {
        if(Debug1_1 == false)
        {
            Debug1_1 = true;
        }
        else
        {
            Debug1_1 = false;
        }
    }
    void OnPrintConnectStatus (InputValue value)
    {
         if(Debug2 == false)
        {
            Debug2 = true;
        }
        else
        {
            Debug2 = false;
        }

    }
    void OnPrintLayerStatus (InputValue value)
    {
         if(Debug3 == false)
        {
            Debug3 = true;
        }
        else
        {
            Debug3 = false;
        }
    }

    void OnActivateDebugHelp (InputValue value)
    {
        if(ActivateDebug == false)
        {
            DebugHelpUI.SetActive(true);
        }
        else
        {
            DebugHelpUI.SetActive(false);
        }
    }
   
}
