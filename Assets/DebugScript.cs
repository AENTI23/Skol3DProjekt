using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugScript : MonoBehaviour
{
    public bool TurnOnDebug;
    public bool ActivateDebugHelpText;
    public bool Debug1;
    public bool Debug2;
    public bool Debug3;
    public bool Debug4;
    public bool Debug1_1;


    public GameObject DebugHelpUI;

    public GameObject DebugActivatedText;

    public GameObject emptycontrol;

    public GameObject pcobject;

    emtycontrol emtpy;

    PlayersController PlayersControl;



    void Start()
    {
        emtpy = emptycontrol.GetComponent<emtycontrol>();
        PlayersControl = pcobject.GetComponent<PlayersController>();

    }


    void OnNewBrickInOrder (InputValue value)
    {
        if(TurnOnDebug == true)
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

    }
    void OnNewBrickInOrderMinus (InputValue value)
    {
        if(TurnOnDebug == true)
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
    }
    void OnPrintConnectStatus (InputValue value)
    {
        if(TurnOnDebug == true)
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

    }
    void OnPrintLayerStatus (InputValue value)
    {
        if(TurnOnDebug == true)
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
    }

    void OnActivateDebugHelp (InputValue value)
    {
        if(TurnOnDebug == true)
        {

        if(ActivateDebugHelpText == false)
        {
            DebugHelpUI.SetActive(true);
            ActivateDebugHelpText = true;
        }
        else
        {
            ActivateDebugHelpText = false;
            DebugHelpUI.SetActive(false);
        }
        }
    }

    void OnEndGameTest (InputValue value)
    {
        if(TurnOnDebug == true)
        {

      PlayersControl.EndGame();
        }
    }

    void OnTurnOnDEBUG (InputValue value)
    {
        if(TurnOnDebug == false)
        {
            TurnOnDebug = true;
            DebugActivatedText.gameObject.SetActive(true);
        }
        else
        {
            TurnOnDebug = false;
            DebugActivatedText.gameObject.SetActive(false);
            DebugHelpUI.gameObject.SetActive(false);
            ActivateDebugHelpText = false;
            Debug1 = false;
            Debug1_1 = false;
            Debug2 = false;
            Debug3 = false;
            Debug4 = false;
        }
    }


   
}
