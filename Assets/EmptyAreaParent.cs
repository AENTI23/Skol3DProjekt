using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class EmptyAreaParent : MonoBehaviour
{
    [SerializeField] GameObject[] nextspawn;
    [SerializeField] GameObject EmptyAreaPrefab;

    public GameObject EmptyHolder;

    [SerializeField] bool[] SpawnAnother;

    public bool[] ConnectYes;

    public Vector3 PlacerRotation;

    public GameObject placer;

      public MouseScript msscript;

    Vector3 rotationvector;

    Vector3 rotfix;

    Vector3 rotfix2;

    public emptyarea2 othercon;

    // Start is called before the first frame update
    void Start()
    {
         var brickpre = Resources.Load<GameObject>("EmptyAreaCheck1");
         msscript = GameObject.FindWithTag("Mouse").GetComponent<MouseScript>();

         EmptyAreaPrefab = brickpre;

         othercon = GetComponentInChildren<emptyarea2>();

    }

    // Update is called once per frame
    void Update()
    {

        
        PlacerRotation.y = msscript.rotationVector.y;
        rotfix.y = PlacerRotation.y;
        rotfix.y -= 90;

        rotfix2.y = PlacerRotation.y;
        rotfix2.y += 90;



        /*
        if(SpawnAnother[1] == true)
        {
            Instantiate(EmptyAreaPrefab, nextspawn[1].transform.position, Quaternion.identity);

        }
        */
    }

  public void spawnmethod()
    {/*
        if(SpawnAnother[0] == true && ConnectYes[0] == true)
        {
        Instantiate(EmptyAreaPrefab, nextspawn[0].transform.position, Quaternion.Euler(PlacerRotation));
        print("Spawnmethod");
        SpawnAnother[0] = false;
        }
        if(SpawnAnother[1] == true && ConnectYes[1] == true)
        {
        Instantiate(EmptyAreaPrefab, nextspawn[1].transform.position, Quaternion.Euler(PlacerRotation));
        print("Spawnmethod");
        SpawnAnother[1] = false;
        }
        if(SpawnAnother[2] == true && ConnectYes[2] == true)
        {
        Instantiate(EmptyAreaPrefab, nextspawn[2].transform.position, Quaternion.Euler(PlacerRotation));
        print("Spawnmethod");
        SpawnAnother[2] = false;
        }
        */
        if(SpawnAnother[0] == true && ConnectYes[0] == true)
        {
        Instantiate(EmptyAreaPrefab, nextspawn[0].transform.position, Quaternion.Euler(PlacerRotation));//Quaternion.Euler(rotfix));
        print("Spawnmethod");
        SpawnAnother[0] = false;
        }
        if(SpawnAnother[1] == true && ConnectYes[1] == true)
        {
        Instantiate(EmptyAreaPrefab, nextspawn[1].transform.position, Quaternion.Euler(0, rotationvector.y, 0));
        print("Spawnmethod");
        SpawnAnother[1] = false;
        }
        if(SpawnAnother[2] == true && ConnectYes[2] == true)
        {
        Instantiate(EmptyAreaPrefab, nextspawn[2].transform.position, Quaternion.Euler(0, rotationvector.y, 0));
        print("Spawnmethod");
        SpawnAnother[2] = false;
        }

    }

    public void spawnmethod2()
    {
        var brickpre = Resources.Load<GameObject>("EmptyAreaCheck1");
       
        Instantiate(brickpre, nextspawn[2].transform.position, Quaternion.identity);//Quaternion.Euler(rotfix2));
        print("Spawnmethod");
        
    }
}
