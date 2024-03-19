using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
  
  [SerializeField] MeshRenderer AllowPlace;

   [SerializeField] 
   Material Allowed;

    [SerializeField] 
    Material NotAllowed;

    public bool IsPlaced;

      MouseScript placescript;


    // Start is called before the first frame update
    void Start()
    {
 
         placescript = GameObject.FindWithTag("Mouse").GetComponent<MouseScript>();
       if(IsPlaced!)
       {
        Destroy(this.gameObject);
       }
    }

    // Update is called once per frame
    void Update()
    {
             
if(placescript.PlaceOk!)
{
   AllowPlace.material = Allowed;
}
else
{
   AllowPlace.material = NotAllowed;
}
             
    }
}
