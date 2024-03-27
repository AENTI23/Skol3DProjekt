using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCheckParent : MonoBehaviour
{
   public EmptyCheck[] ChildScript;

   [SerializeField] GameObject InsideObject;

   [SerializeField] public Collider[] InsideCollider;

   [SerializeField] Vector3 Size;

   public bool m_Started = true;

   [SerializeField] LayerMask insidelayer;

     [SerializeField] int NextPosX;

     [SerializeField] int NextPosZ;

    [SerializeField] float timer;

    [SerializeField] Vector3 NextPos;

    [SerializeField] Vector3 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        ChildScript = GetComponentsInChildren<EmptyCheck>();
        transform.position = StartPos;
        NextPos = StartPos;
    }

    void FixedUpdate()
    {
        /*
        if(transform.position.z == -5)
        {
            NextPos.x ++;
            NextPos.z = StartPos.z;
            NextPosZ = (int)StartPos.z;
            transform.position = NextPos;
        }
        else
        {
            
        NextPos.z = NextPosZ;
        transform.position = NextPos;
        NextPosZ -= 1;
        }
*/
    
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(transform.position.z == -5 && timer > 0.5f)
        {
            NextPos.x ++;
            NextPos.z = StartPos.z;
            NextPosZ = (int)StartPos.z;
            transform.position = NextPos;
            timer = 0;
        }
        else if(timer > 0.5f)
        {
            
        NextPos.z = NextPosZ;
        transform.position = NextPos;
        NextPosZ -= 1;
        timer = 0;
        }









        if(ChildScript[0].Connected.Length > 0 && ChildScript[1].Connected.Length > 0 && InsideCollider.Length == 0)
        {
            print("Detected possible");

        }


         InsideCollider = Physics.OverlapBox(InsideObject.transform.position, Size, Quaternion.identity, insidelayer);
        int i = 0;
        while (i < InsideCollider.Length)
        {
            i++;
        }

        

    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
        {

            Gizmos.DrawWireCube(InsideObject.transform.position,Size);
            
        }
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    }
}
