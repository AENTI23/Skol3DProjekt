using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCon_3 : MonoBehaviour
{
    public bool m_Started;

    public LayerMask ConnectLayer;

    public LayerMask ErrorLayers;

    public Collider[] AllowedConnect;

    public bool ConnectDetected;

    public Collider[] ErrorConnect;

    public bool ErrorDetected;

    public Vector3 Size;

    public Vector3[] CurrentSize;

    public trackmouse Placer;


  //  public bool[] CollectionBools;


     

    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;
        
    }
    void Update()
    {
       
        MyCollisions();
        if(AllowedConnect.Length > 0)
        {
            ConnectDetected = true;
        }
        else
        {
            ConnectDetected = false;
        }

        if(ErrorConnect.Length > 0)
        {
            ErrorDetected = true;
        }
        else
        {
            ErrorDetected = false;
        }
        

        
        
/*
        for(int AL = 0; AL < CollectionBools.Length; AL ++)
        {
            if(CollectionBools[AL]== true)
            {
                print("one or more is true");
            }

        }
        */
    }
    
    void MyCollisions()
    {
        
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
     
        AllowedConnect = Physics.OverlapBox(gameObject.transform.position, Size, transform.localRotation, ConnectLayer);
        int i = 0;
        // CurrentSize[Placer.RotPoint]
        while (i < AllowedConnect.Length)
        {
            //Output all of the collider names
            Debug.Log("Allow Connect:" + gameObject);
            //Increase the number of Colliders in the array
            i++;
        }


       ErrorConnect = Physics.OverlapBox(gameObject.transform.position, Size, transform.localRotation, ErrorLayers);
        int i2 = 0;
        while (i2 < ErrorConnect.Length)
        {
            Debug.Log("ERROR Connect" + gameObject);
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

         //   Gizmos.DrawWireCube(transform.position,CurrentSize[Placer.RotPoint]);
        }
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    }
}
