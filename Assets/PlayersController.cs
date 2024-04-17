using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayersController : MonoBehaviour
{
    [SerializeField] String[] Players;

    [SerializeField] Color[] PlayerColors;

    public int CurrentPlayer;

    [SerializeField] int[] PlayerPoints;

    [SerializeField] int[] PlayerPlacers;

    public LayerMask[] AntiLayers;

    public static int MaxPlayers = 1;

    [SerializeField] TextMeshProUGUI DisplayName;

    [SerializeField] GameObject SelectText;

    public bool Selecting;

    [SerializeField] GameObject Placer;

    public bool ReRunroadbools;

    // Start is called before the first frame update
    void Start()
    {
         DisplayName.text = Players[CurrentPlayer];
    }

    public void NewRotation()
    {
        Placer.SetActive(true);
        SelectText.SetActive(false);
        ReRunroadbools = false;
             Selecting = false;
        if(CurrentPlayer != MaxPlayers)
        {
        CurrentPlayer += 1;
        DisplayName.text = Players[CurrentPlayer];
        print("NewRotation!");
     //  DisplayName.color = PlayerColors[CurrentPlayer];
        }
        else
        {
              print("NewRotation!2");
            DisplayName.text = Players[0];
       // DisplayName.color = PlayerColors[0];
            CurrentPlayer = 0;
        }
    }

    public void SelectPeriod()
    {
        Selecting = true;
        SelectText.SetActive(true);
        Placer.SetActive(false);
    }

    public void ReRunRoadTriggers()
    {
        ReRunroadbools = true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GivePointRoad()
    {
        PlayerPoints[CurrentPlayer] += 1;
        print(PlayerPoints[CurrentPlayer] + "Player Point" + "Player =" + Players[CurrentPlayer]);
        print("Succesfull Point!");
    }
}
