using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectController : MonoBehaviour
{
     public bool m_Started;

    public LayerMask[] ConnectLayer;

    public LayerMask[] ErrorLayers;

    public Collider[] AllowedConnect;

    public bool ConnectDetected;

    public Collider[] ErrorConnect;

    public bool ErrorDetected;

    public Vector3 Size;

    public string CurrentWall;

    public MouseScript PlaceScript;

    public int[] CityBricks;

    public int[] RoadBricks;

    public int[] GrassBricks;

    public int[] WaterBricks;

    public bool Connect1bool;

    public LayerMask CurrentLayer;

    public LayerMask ErrorLayer;

    public string ThisConnecter;

    DebugScript Debugging;


  //  public bool[] CollectionBools;


     

    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;

        Debugging = GameObject.FindWithTag("Debug").GetComponent<DebugScript>();

        
    }
    void Update()
    {
        MyCollisions();

        ConnectSorting();


        if(AllowedConnect.Length > 0)
        {
            ConnectDetected = true;
        }
        else if(AllowedConnect.Length == 0)
        {
            ConnectDetected = false;
        }
        if(ErrorConnect.Length > 0)
        {
            ErrorDetected = true;
        }
        else if(ErrorConnect.Length == 0)
        {
            ErrorDetected = false;
        }
       
    }

    void ConnectSorting()
    {
       

         for(int AL2 = 0; AL2 < CityBricks.Length; AL2 ++) //Loop kollar ifall den nuvarande brickan är en som ska göra denna connector till city, de andra loops göra samma sak fast för water,grass och road.
        {
            if(CityBricks[AL2] == PlaceScript.BrickNumber)
            {
                CurrentLayer = ConnectLayer[0];
                ErrorLayer = ErrorLayers[0];

                if(Debugging.Debug3!)
                {
                print(ThisConnecter + "CITY!! YES");
                }
            }
        }

        for(int AL3 = 0; AL3 < RoadBricks.Length; AL3 ++)
        {
            if(RoadBricks[AL3] == PlaceScript.BrickNumber)
            {
                CurrentLayer = ConnectLayer[1];
                ErrorLayer = ErrorLayers[1];
                if(Debugging.Debug3!)
                {
                print(ThisConnecter + "ROAD!!! YES");
                }
            }
        }

        for(int AL4 = 0; AL4 < GrassBricks.Length; AL4 ++)
        {
            if(GrassBricks[AL4] == PlaceScript.BrickNumber)
            {
                CurrentLayer = ConnectLayer[2];
                ErrorLayer = ErrorLayers[2];
                if(Debugging.Debug3!)
                {
                print(ThisConnecter + "GRASS!!! YES");
                }
            }
        }

        for(int AL5 = 0; AL5 < WaterBricks.Length; AL5 ++)
        {
            if(WaterBricks[AL5] == PlaceScript.BrickNumber)
            {
                CurrentLayer = ConnectLayer[3];
                ErrorLayer = ErrorLayers[3];
                if(Debugging.Debug3!)
                {
                print(ThisConnecter + "WATER!!! YES");
                }
            }
        }
        
    }
    
    void MyCollisions()
    {
        
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
     
        AllowedConnect = Physics.OverlapBox(gameObject.transform.position, Size, Quaternion.identity, CurrentLayer);
        int i = 0;
        while (i < AllowedConnect.Length)
        {
            //Output all of the collider names
            
            if(Debugging.Debug2!) Debug.Log("Allow Connect:" + CurrentWall);
            //Increase the number of Colliders in the array
            i++;
        }

       ErrorConnect = Physics.OverlapBox(gameObject.transform.position, Size, Quaternion.identity, ErrorLayer);
        int i2 = 0;
        while (i2 < ErrorConnect.Length)
        {
            if(Debugging.Debug2!)Debug.Log("ERROR Connect" + CurrentWall);
            i2++;
        }
    }
    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
        {

            Gizmos.DrawWireCube(transform.position,Size);
            
        }
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    }
}
