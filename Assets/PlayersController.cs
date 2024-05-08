using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayersController : MonoBehaviour
{
    [SerializeField] String[] Players;


    [SerializeField] Color[] PlayerColors;

    public int CurrentPlayer;

   [SerializeField] public int[] PlayerPoints;
    [SerializeField] public TextMeshProUGUI[] PlayerPointsUI;

    [SerializeField] public int[] PlayerPlacers;

    [SerializeField] public GameObject[] PlayerPlacersUIs;

    [SerializeField] public GameObject PlacersUiParent;

    [SerializeField] public static int MaxPlayers = 1;

    [SerializeField] TextMeshProUGUI DisplayName;

    [SerializeField] GameObject SelectText;

    public bool Selecting;

    [SerializeField] GameObject Placer;

    [SerializeField] GameObject SkipButton;

    public bool ReRunroadbools;

    public bool ReRunCitybool;

    public bool ReRunWaterbool;

    public bool IsGameScene;

    public int BricksPlacedTotal;

    public static int RedPoint;

    public static int GreenPoint;

    public static int BluePoint;

    public static int YellowPoint;

    // Start is called before the first frame update
    void Start()
    {
         if(IsGameScene == true)
         {
             print(MaxPlayers + 1 + "This many players (adjusted for array)");
         DisplayName.text = Players[CurrentPlayer];
         if(MaxPlayers == 1)
         {
            PlayerPointsUI[0].gameObject.SetActive(true);
            PlayerPointsUI[1].gameObject.SetActive(true);
            PlayerPointsUI[2].gameObject.SetActive(false);
            PlayerPointsUI[3].gameObject.SetActive(false);
         }
         else if(MaxPlayers == 2)
         {
            PlayerPointsUI[0].gameObject.SetActive(true);
            PlayerPointsUI[1].gameObject.SetActive(true);
            PlayerPointsUI[2].gameObject.SetActive(true);
            PlayerPointsUI[3].gameObject.SetActive(false);
         }
         else if(MaxPlayers == 3)
         {
            PlayerPointsUI[0].gameObject.SetActive(true);
            PlayerPointsUI[1].gameObject.SetActive(true);
            PlayerPointsUI[2].gameObject.SetActive(true);
            PlayerPointsUI[3].gameObject.SetActive(true);
         }
         }
    }

    public void TwoPlayers()
    {
        MaxPlayers = 1;
        print(MaxPlayers);
    }

    public void ThreePlayers()
    {
        MaxPlayers = 2;
        print(MaxPlayers);
    }

    public void FourPlayers()
    {
        MaxPlayers = 3;
         print(MaxPlayers);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NewRotation()
    {
        Placer.SetActive(true);
        SelectText.SetActive(false);
        SkipButton.SetActive(false);
          ReRunroadbools = false;
          ReRunCitybool = false;
          ReRunWaterbool = false;
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
        SkipButton.SetActive(true);
        PlacersUiParent.SetActive(true);
        //PlayerPlacersUIs[Length.(PlayerPlacers[CurrentPlayer])].SetActive(true, )

    }

    public void ReRunRoadTriggers()
    {
        ReRunroadbools = true;
    }
    public void ReRunCityTriggers()
    {
        ReRunCitybool = true;
    }
    public void ReRunWaterTriggers()
    {
        ReRunWaterbool = true;
    }
    public void GivePoint()
    {
        PlayerPoints[CurrentPlayer] += 1;
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }
    public void GivePointWater()
    {
        PlayerPoints[CurrentPlayer] += 2;
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }
    public void GivePointCity()
    {
        PlayerPoints[CurrentPlayer] += 3;
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }

    public void EndGame()
    {
        RedPoint = PlayerPoints[0];
        GreenPoint = PlayerPoints[1];
        BluePoint = PlayerPoints[2];
        YellowPoint = PlayerPoints[3];
        
    }



   
}
