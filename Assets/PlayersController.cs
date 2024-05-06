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

   [SerializeField] public int[] PlayerPoints;
    [SerializeField] public TextMeshProUGUI[] PlayerPointsUI;

    [SerializeField] int[] PlayerPlacers;

    public LayerMask[] AntiLayers;

    public static int MaxPlayers = 1;

    [SerializeField] TextMeshProUGUI DisplayName;

    [SerializeField] GameObject SelectText;

    public bool Selecting;

    [SerializeField] GameObject Placer;

    public bool ReRunroadbools;

    public bool ReRunCitybool;

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
          ReRunCitybool = false;
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
    public void GivePoint()
    {
        PlayerPoints[CurrentPlayer] += 1;
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }
    public void GivePointCity()
    {
        PlayerPoints[CurrentPlayer] += 2;
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }

    public void ReRunCityTriggers()
    {
        ReRunCitybool = true;

    }

   
}
