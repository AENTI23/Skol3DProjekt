using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Linq;

public class PlayersController : MonoBehaviour
{
    [SerializeField] String[] Players;
    [SerializeField] Color[] PlayerColors;
    public int CurrentPlayer;
   [SerializeField] public int[] PlayerPoints;
    [SerializeField] GameObject[] PlayerPointsTextParent;
    [SerializeField] public TextMeshProUGUI[] PlayerPointsUI;
    [SerializeField] public int[] PlayerPlacers;
    [SerializeField] public GameObject[] PlayerPlacersUIs;
    [SerializeField] public GameObject PlacersUiParent;
    [SerializeField] public int[] CountingPoints;
    public TextMeshProUGUI PointProgressText;
    [SerializeField] public int GiveBackLimit;

    [SerializeField] GameObject[] plustext;
    [SerializeField] public static int MaxPlayers = 1;
    [SerializeField] TextMeshProUGUI DisplayName;
    [SerializeField] GameObject SelectText;
    public bool Selecting;
    [SerializeField] GameObject Placer;
    [SerializeField] GameObject SkipButton;
    [SerializeField] GameObject SkipPlacingButton;
    public bool ReRunCollisionsBool;
    public bool IsGameScene;
    public int BricksPlacedTotal;

    public AudioSource ClaimSound;

    MouseScript mouseScript;


// SlutScene Variabler
    public static int RedPoint;
    public static int GreenPoint;
    public static int BluePoint;
    public static int YellowPoint;
    public bool IsEndScene;
    static int FirstPlace;
    static int WhoIsFirstPlace;

    public TextMeshProUGUI WinnerDisplay;



    // Start is called before the first frame update
    void Start()
    {
         if(IsGameScene == true)
         {
          mouseScript = GameObject.FindWithTag("Mouse").GetComponent<MouseScript>();
             print(MaxPlayers + 1 + "This many players (adjusted for array)");
         DisplayName.text = Players[CurrentPlayer];
         if(MaxPlayers == 1)
         {
            PlayerPointsUI[0].gameObject.SetActive(true);
            PlayerPointsUI[1].gameObject.SetActive(true);
            PlayerPointsUI[2].gameObject.SetActive(false);
            PlayerPointsUI[3].gameObject.SetActive(false);
            GiveBackLimit = 6;
         }
         else if(MaxPlayers == 2)
         {
            PlayerPointsUI[0].gameObject.SetActive(true);
            PlayerPointsUI[1].gameObject.SetActive(true);
            PlayerPointsUI[2].gameObject.SetActive(true);
            PlayerPointsUI[3].gameObject.SetActive(false);
         
            GiveBackLimit = 5;
         }
         else if(MaxPlayers == 3)
         {
            PlayerPointsUI[0].gameObject.SetActive(true);
            PlayerPointsUI[1].gameObject.SetActive(true);
            PlayerPointsUI[2].gameObject.SetActive(true);
            PlayerPointsUI[3].gameObject.SetActive(true);
            GiveBackLimit = 4;
         }
         }

         if(IsEndScene == true)
         {
          Results();

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
          else if (MaxPlayers == 3)
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
      mouseScript.PickBrick();
        GiveBackPlacers();
        Placer.SetActive(true);
        SelectText.SetActive(false);
        SkipButton.SetActive(false);
        SkipPlacingButton.SetActive(true);
        ReRunCollisionsBool = false;
        Selecting = false;
        if(CurrentPlayer != MaxPlayers)
        {
        CurrentPlayer += 1;
        DisplayName.text = Players[CurrentPlayer];
        DisplayName.color = PlayerColors[CurrentPlayer];
       int LastPlayer = CurrentPlayer;
       LastPlayer -= 1;
        QuickUIfix();

        print(LastPlayer + "LastPlayer");
        if(PlayerPoints[LastPlayer] > 99)
        {
            Transform PointsParent;
            PointsParent = PlayerPointsTextParent[LastPlayer].GetComponent<Transform>();
            PointsParent.transform.localPosition = new Vector3(850,PointsParent.localPosition.y, 0);

        }
        else if(PlayerPoints[LastPlayer] > 9)
        {
            Transform PointsParent;
            PointsParent = PlayerPointsTextParent[LastPlayer].GetComponent<Transform>();
            PointsParent.transform.localPosition = new Vector3(885,PointsParent.localPosition.y, 0);
        }
        }
        else
        {
          DisplayName.text = Players[0];
          DisplayName.color = PlayerColors[0];
            CurrentPlayer = 0;
            int LastPlayer = MaxPlayers;
              QuickUIfix();


            if(PlayerPoints[LastPlayer] > 99)
            {
                Transform PointsParent;
            PointsParent = PlayerPointsTextParent[LastPlayer].GetComponent<Transform>();
            PointsParent.transform.localPosition = new Vector3(850,PointsParent.localPosition.y, 0);

            }
            else if(PlayerPoints[LastPlayer] > 9)
            {
                Transform PointsParent;
            PointsParent = PlayerPointsTextParent[LastPlayer].GetComponent<Transform>();
            PointsParent.transform.localPosition = new Vector3(885,PointsParent.localPosition.y, 0);

            }
        }
    }

    public void GiveBackPlacers()
    {
        if(CountingPoints[0] > GiveBackLimit && PlayerPlacers[0] != 5)
        {
          PlayerPlacers[0] += 1;
          CountingPoints[0] -= GiveBackLimit;
          plustext[0].SetActive(true);
        }

        if(CountingPoints[1] > GiveBackLimit && PlayerPlacers[1] != 5)
        {
          PlayerPlacers[1] += 1;
          CountingPoints[1] -= GiveBackLimit;
          plustext[1].SetActive(true);

        }

        if(CountingPoints[2] > GiveBackLimit && PlayerPlacers[2] != 5)
        {
          PlayerPlacers[2] += 1;
          CountingPoints[2] -= GiveBackLimit;
          plustext[2].SetActive(true);
        }

        if(CountingPoints[3] > GiveBackLimit && PlayerPlacers[3] != 5)
        {
          PlayerPlacers[3] += 1;
          CountingPoints[3] -= GiveBackLimit;
          plustext[3].SetActive(true);
        }
        
      

    }

    public void SelectPeriod()
    {
          GiveBackPlacers();
        Selecting = true;
        SelectText.SetActive(true);
        PlacersUiParent.SetActive(true);
        Placer.SetActive(false);
        SkipButton.SetActive(true);
        SkipPlacingButton.SetActive(false);
         QuickUIfix();
       
    }

    public void QuickUIfix()
    {
      GiveBackPlacers();
       PlayerPlacersUIs[0].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[1].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[2].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[3].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[4].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[5].GetComponent<TextMeshProUGUI>().color = PlayerColors[CurrentPlayer];
        if(PlayerPlacers[CurrentPlayer] == 5)
        {
          PointProgressText.text = CountingPoints[CurrentPlayer].ToString() + "/" + GiveBackLimit.ToString();
          PointProgressText.color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(true);
          PlayerPlacersUIs[4].SetActive(true);
           PlayerPlacersUIs[5].SetActive(false);
        }
        else if(PlayerPlacers[CurrentPlayer] == 4)
        {
          PointProgressText.text = CountingPoints[CurrentPlayer].ToString() + "/" + GiveBackLimit.ToString();
          PointProgressText.color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(true);
          PlayerPlacersUIs[4].SetActive(false);
           PlayerPlacersUIs[5].SetActive(false);
        }
        else if (PlayerPlacers[CurrentPlayer] == 3)
        {
          PointProgressText.text = CountingPoints[CurrentPlayer].ToString() + "/" + GiveBackLimit.ToString();
          PointProgressText.color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
           PlayerPlacersUIs[5].SetActive(false);
        }
        else if (PlayerPlacers[CurrentPlayer] == 2)
        {
          PointProgressText.text = CountingPoints[CurrentPlayer].ToString() + "/" + GiveBackLimit.ToString();
          PointProgressText.color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
           PlayerPlacersUIs[5].SetActive(false);
        }
        else if(PlayerPlacers[CurrentPlayer] == 1)
        {
          PointProgressText.text = CountingPoints[CurrentPlayer].ToString() + "/" + GiveBackLimit.ToString();
          PointProgressText.color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(false);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
           PlayerPlacersUIs[5].SetActive(false);
        }
        else if(PlayerPlacers[CurrentPlayer] == 0)
        {
          PointProgressText.text = CountingPoints[CurrentPlayer].ToString() + "/" + GiveBackLimit.ToString();
          PointProgressText.color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[0].SetActive(false);
          PlayerPlacersUIs[1].SetActive(false);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
          PlayerPlacersUIs[5].SetActive(true);
        }
    }

    public void ReRunCollisions()
    {
        ReRunCollisionsBool = true;
    }
    public void GivePoint()
    {
      if(mouseScript.AllBricksPlaced == false)
      {

        PlayerPoints[CurrentPlayer] += 1;
        CountingPoints[CurrentPlayer] += 1;
      }
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }
    public void GivePointWater()
    {
      if(mouseScript.AllBricksPlaced == false)
      {

        PlayerPoints[CurrentPlayer] += 2;
        CountingPoints[CurrentPlayer] += 2;
      }
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }
    public void GivePointCity()
    {
      if(mouseScript.AllBricksPlaced == false)
      {

        PlayerPoints[CurrentPlayer] += 2;
        CountingPoints[CurrentPlayer] += 2;
      }
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }

    public void EndGame()
    {
        RedPoint = PlayerPoints[0];
        GreenPoint = PlayerPoints[1];
        BluePoint = PlayerPoints[2];
        YellowPoint = PlayerPoints[3];
        

        FirstPlace = PlayerPoints.Max();

        WhoIsFirstPlace = Array.IndexOf(PlayerPoints, FirstPlace);

        SceneManager.LoadScene(2);


      
    }

    public void Results()
    {
      PlayerPointsUI[0].text = "Red: " + RedPoint.ToString();
      PlayerPointsUI[1].text = "Green: " + GreenPoint.ToString();
      PlayerPointsUI[2].text = "Blue: " + BluePoint.ToString();
      PlayerPointsUI[3].text = "Yellow: " + YellowPoint.ToString();

      if(WhoIsFirstPlace == 0)
      {
        WinnerDisplay.text = "Red";
        WinnerDisplay.color = PlayerColors[0];

      }
      else if(WhoIsFirstPlace == 1)
      {
        WinnerDisplay.text = "Green";
        WinnerDisplay.color = PlayerColors[1];

      }
      else if (WhoIsFirstPlace == 2)
      {
        WinnerDisplay.text = "Blue";
        WinnerDisplay.color = PlayerColors[2];

      }
      else if (WhoIsFirstPlace == 3)
      {
        WinnerDisplay.text = "Yellow";
        WinnerDisplay.color = PlayerColors[3];
      }

    }

    public void ReturnToStart()
    {
      SceneManager.LoadScene(0);
    }

}
