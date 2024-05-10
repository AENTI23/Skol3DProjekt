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
    [SerializeField] GameObject[] PlayerPointsTextParent;
    [SerializeField] public TextMeshProUGUI[] PlayerPointsUI;
    [SerializeField] public int[] PlayerPlacers;
    [SerializeField] public GameObject[] PlayerPlacersUIs;
    [SerializeField] public GameObject PlacersUiParent;
    [SerializeField] public int[] CountingPoints;

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
    public static int RedPoint;
    public static int GreenPoint;
    public static int BluePoint;
    public static int YellowPoint;

    public AudioSource ClaimSound;


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
        GiveBackPlacers();
        Placer.SetActive(true);
        SelectText.SetActive(false);
        SkipButton.SetActive(false);
        PlacersUiParent.SetActive(false);
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
        print(LastPlayer + "LastPlayer");
        if(PlayerPoints[LastPlayer] > 99)
        {
            Transform PointsParent;
            PointsParent = PlayerPointsTextParent[LastPlayer].GetComponent<Transform>();
            PointsParent.transform.position = new Vector3(850,PointsParent.localPosition.y, 0);

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
            if(PlayerPoints[LastPlayer] > 99)
            {
                Transform PointsParent;
            PointsParent = PlayerPointsTextParent[LastPlayer].GetComponent<Transform>();
            PointsParent.transform.position = new Vector3(850,PointsParent.localPosition.y, 0);

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
        if(CountingPoints[0] > 7 && PlayerPlacers[0] != 5)
        {
          PlayerPlacers[0] += 1;
          CountingPoints[0] -= 7;
          plustext[0].SetActive(true);
        }

        if(CountingPoints[1] > 7 && PlayerPlacers[1] != 5)
        {
          PlayerPlacers[1] += 1;
          CountingPoints[1] -= 7;
          plustext[1].SetActive(true);
        }

        if(CountingPoints[2] > 7 && PlayerPlacers[2] != 5)
        {
          PlayerPlacers[2] += 1;
          CountingPoints[2] -= 7;
            plustext[2].SetActive(true);

        
        }

        if(CountingPoints[3] > 7 && PlayerPlacers[3] != 5)
        {
          PlayerPlacers[3] += 1;
          CountingPoints[3] -= 7;
                    plustext[3].SetActive(true);

        }
    }

    public void SelectPeriod()
    {
        Selecting = true;
        SelectText.SetActive(true);
        PlacersUiParent.SetActive(true);
        Placer.SetActive(false);
        SkipButton.SetActive(true);
        SkipPlacingButton.SetActive(false);
        if(PlayerPlacers[CurrentPlayer] == 5)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(true);
          PlayerPlacersUIs[4].SetActive(true);
        }
        else if(PlayerPlacers[CurrentPlayer] == 4)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(true);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if (PlayerPlacers[CurrentPlayer] == 3)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if (PlayerPlacers[CurrentPlayer] == 2)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if(PlayerPlacers[CurrentPlayer] == 1)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(false);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if(PlayerPlacers[CurrentPlayer] == 0)
        {
          PlayerPlacersUIs[0].SetActive(false);
          PlayerPlacersUIs[1].SetActive(false);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
          PlayerPlacersUIs[0].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[1].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[2].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[3].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
          PlayerPlacersUIs[4].GetComponent<RawImage>().color = PlayerColors[CurrentPlayer];
       
    }

    public void QuickUIfix()
    {
        if(PlayerPlacers[CurrentPlayer] == 5)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(true);
          PlayerPlacersUIs[4].SetActive(true);
        }
        else if(PlayerPlacers[CurrentPlayer] == 4)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(true);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if (PlayerPlacers[CurrentPlayer] == 3)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(true);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if (PlayerPlacers[CurrentPlayer] == 2)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(true);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if(PlayerPlacers[CurrentPlayer] == 1)
        {
          PlayerPlacersUIs[0].SetActive(true);
          PlayerPlacersUIs[1].SetActive(false);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
        else if(PlayerPlacers[CurrentPlayer] == 0)
        {
          PlayerPlacersUIs[0].SetActive(false);
          PlayerPlacersUIs[1].SetActive(false);
          PlayerPlacersUIs[2].SetActive(false);
          PlayerPlacersUIs[3].SetActive(false);
          PlayerPlacersUIs[4].SetActive(false);
        }
    }

    public void ReRunCollisions()
    {
        ReRunCollisionsBool = true;
    }
    public void GivePoint()
    {
        PlayerPoints[CurrentPlayer] += 1;
        CountingPoints[CurrentPlayer] += 1;
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }
    public void GivePointWater()
    {
        PlayerPoints[CurrentPlayer] += 2;
        CountingPoints[CurrentPlayer] += 2;
        PlayerPointsUI[CurrentPlayer].text = PlayerPoints[CurrentPlayer].ToString();   
    }
    public void GivePointCity()
    {
        PlayerPoints[CurrentPlayer] += 2;
        CountingPoints[CurrentPlayer] += 2;
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
