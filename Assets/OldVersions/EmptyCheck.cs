using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCheck : MonoBehaviour
{
    [SerializeField] Vector3 Size;
    [SerializeField] LayerMask ConLayers;

    public Collider[] Connected;

    public bool m_Started = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   


         Connected = Physics.OverlapBox(gameObject.transform.position, Size, Quaternion.identity, ConLayers);
        int i = 0;
        while (i < Connected.Length)
        {
            i++;
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
        {

            Gizmos.DrawWireCube(transform.position,Size);
            
        }
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    }
}
