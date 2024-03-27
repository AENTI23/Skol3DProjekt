using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;

public class EmptyAreaConnect : MonoBehaviour
{
  [SerializeField] EmptyAreaParent parentscript;

  [SerializeField] Collider[] Connected;

    [SerializeField] Collider[] NotConnected;

   [SerializeField] emptyarea2 otherspawn;

    public Vector3 Size;

    public LayerMask thislayer;

    public LayerMask emptylayer;

    public bool m_Started;

    [SerializeField] DebugScript Debugging;

    [SerializeField] bool acticol2 = false;

    [SerializeField] float waittime = 0;

    [SerializeField] int ObjectNumber;

    bool lockthis;

    bool lockthis2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(activatecol2), 0.5f);
        parentscript = GetComponentInParent<EmptyAreaParent>();
         Debugging = GameObject.FindWithTag("Debug").GetComponent<DebugScript>();
         waittime = 0;
         otherspawn = parentscript.othercon;
    }

    void Update()
    {
        waittime += Time.deltaTime;



         Connected = Physics.OverlapBox(gameObject.transform.position, Size, Quaternion.identity, thislayer);
        int i = 0;
        while (i < Connected.Length)
        {
            i++;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
if(Debugging.Debug4 == true)
{
  if(Connected.Length == 0 && waittime > 5f && lockthis == false) //&& NotConnected.Length == 0) //&& NotConnected.Length == 0 && lockthis == false)
      {
        parentscript.ConnectYes[ObjectNumber] = true;
       parentscript.spawnmethod();
       print("WOWWW");
       lockthis = true;
       Destroy(this.gameObject);
     } 
     else if(waittime > 6f && otherspawn.Connected.Length == 0 && lockthis2 == false )
     {
        lockthis2 = true;
        parentscript.spawnmethod2();
        Destroy(this.gameObject);
     }
     else if(waittime > 10f)
     {
        Destroy(this.gameObject);
     }
}


        
if(acticol2 == true)
{
    Collision2();
}

    }

    public void activatecol2()
    {
        acticol2 = true;

    }

    private void Collision2()
    {
        // kanske inte behövs en "error/notconnected" overlapbox.
        NotConnected = Physics.OverlapBox(gameObject.transform.position, Size, Quaternion.identity, emptylayer);
        int i2 = 0;
        while (i2 < Connected.Length)
        {
            i2++;
        }

    }

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
