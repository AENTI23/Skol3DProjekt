using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectCon2 : MonoBehaviour
{
    [SerializeField]
    LayerMask CityLayer; //Lager specification så att jumpswitch bool bara blir true när den nuddar marken eftersom den har groundlayer

    [SerializeField]
    Transform groundCheck; // Kollar "transform" positioner o sånt på groundcheck objektet.

    [SerializeField]
    float groundRadius = 0.1f; //Bestämmer storleken på jumpswitch bool boxen

    [SerializeField]
    float groundWidth = 0f; //B

    [SerializeField]
    float groundWidth2 = 0f;

    public Collider[] CityPlaceOk;
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 size = MakeGroundcheckSize();
      CityPlaceOk = Physics.OverlapBox(groundCheck.position, size, Quaternion.identity, CityLayer); // en bool som är positiv ifall groundcheck nuddar marken.
    }

    // Update is called once per frame
    void Update()
    {
        int test = 0;
          while(test < CityPlaceOk.Length)
          {
            print(CityPlaceOk.Length);

          }
        
    
        
    }
    private Vector3 MakeGroundcheckSize() => new Vector3(groundWidth, groundRadius, groundWidth2 );
     private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 size = MakeGroundcheckSize();
        Gizmos.DrawWireCube(groundCheck.position, size);
    }
}
