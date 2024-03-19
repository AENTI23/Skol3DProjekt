using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectConnect : MonoBehaviour
{
   public bool MayPlace = false;

   public bool[] ConnectType2;

   public LayerMask NotThisLayer;

   public LayerMask NotThisLayer2;


  MouseScript placescript;

  public bool DontAllowPlace;

  public DetectConnect[] OtherConnects;

  public String[] ObjectTag;





    // Start is called before the first frame update
    void Start()
    {
        placescript = GameObject.FindWithTag("Mouse").GetComponent<MouseScript>();

    }
void OnTriggerEnter(Collider Other)
{
    if(Other.tag != "BrickInside")
    {

    if(Other.tag == ObjectTag[0] && gameObject.tag == ObjectTag[0] && Other.excludeLayers != NotThisLayer)
    {
       
      if(OtherConnects[0].DontAllowPlace == false && OtherConnects[1].DontAllowPlace == false )
      {
        ConnectType2[0] = true;
     //  placescript.ConnectType[0] = true;
        DontAllowPlace = false;
        print("Succes");
      } 
  
       print(ObjectTag[0]);
    }
     else
      {
        print("Stop it!" + gameObject);
      }
    if(Other.tag == ObjectTag[0] && gameObject.tag == ObjectTag[0] && Other.excludeLayers == NotThisLayer)
    {
       // DontAllowPlace = true;
        //print("dontallowplace" + ObjectTag[0]);
    }
    }
    if(Other.tag != ObjectTag[0] && Other.tag != "BrickInside" && gameObject.tag == ObjectTag[0])
    {
      //print("Stop it!" + gameObject);
    }
   
}
void OnTriggerExit(Collider Other)
{     
   if(ConnectType2[0]!)
   {
     DontAllowPlace = false;
    ConnectType2[0] = false;
  //  placescript.ConnectType[0] = false;
   }     
}


}
