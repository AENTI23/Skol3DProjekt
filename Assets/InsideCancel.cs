using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InsideCancel : MonoBehaviour
{
    public MouseScript PlaceScript;

    public Collider Collis;

    public LayerMask InsideLayer;

    // Start is called before the first frame update
    void Start()
    {
        PlaceScript = GameObject.FindWithTag("Mouse").GetComponent<MouseScript>();
    }
    void OnTriggerEnter(Collider OtherObject)
    {
        Collis = OtherObject;

        //    print("ENTER CANCEL");
            PlaceScript.InsideCancelBool = true;
        
    }

    void OnTriggerStay(Collider OtherObject)
    {
      // print("STAY CANCEL");
        PlaceScript.InsideCancelBool = true;
        Collis = OtherObject;
        
    }

    void OnTriggerExit(Collider OtherObject)
    {
        Collis = OtherObject;
       // print("EXIT CANCEL");
        PlaceScript.InsideCancelBool = false;
        
    }
}
