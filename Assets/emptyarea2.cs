using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyarea2 : MonoBehaviour
{
      public Collider[] Connected;

       public LayerMask thislayer;

          public Vector3 Size;

      bool m_Started;

      [SerializeField] float timer;


    // Start is called before the first frame update
    void Start()
    {
        m_Started = true;
        timer = 0;
    }

    // Update is called once per frame
      void Update()
    {
        timer += Time.deltaTime;

        
         Connected = Physics.OverlapBox(gameObject.transform.position, Size, Quaternion.identity, thislayer);
        int i = 0;
        while (i < Connected.Length)
        {
            i++;
        }

        if(timer > 7)
        {
            Destroy(this.gameObject);
        }
    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
        {

            Gizmos.DrawWireCube(transform.position,Size);
            
        }
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    }
}
