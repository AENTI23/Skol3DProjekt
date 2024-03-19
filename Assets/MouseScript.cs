using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] BrickPrefab;

    [SerializeField]
    GameObject PlacerObject;

    [SerializeField]
    MeshRenderer AllowObject;

    public Material[] AllowMaterial;

    public Material[] BrickMaterials;

    public MeshRenderer ActiveBrick;

   // public bool [] ConnectType;

    public ConnectController[] Connectors;

    public bool[] CompareArray;

    public bool[] CompareArray2;

    public bool PlaceOk;

    public Vector3 rotationVector;

    Vector3 brickspawn;

    public int BrickNumber;

    public int[] BrickLimits;

    public int[] CurrentBrickLimits;

   public DebugScript Debugging;

    

    // Start is called before the first frame update
    void Start()
    {
        PickBrick();
        brickspawn.x = 1;
        rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Instantiate(BrickPrefab[0], brickspawn, Quaternion.identity);
      
        Debugging = GameObject.FindWithTag("Debug").GetComponent<DebugScript>();
    }

    public void PickBrick()
    {
      if(Debugging.Debug1 == false)
      {

      int BrickRandomNumb = Random.Range(1, 57);
      BrickNumber = BrickRandomNumb;
      print("NextBrick" + BrickRandomNumb);
      }
      else if (Debugging.Debug1 == true)
      {
        if(BrickNumber == 56)
        {
            BrickNumber = 1;
        }
        else if(Debugging.Debug1_1 == false)
        {
        BrickNumber += 1;
        }
        else if(Debugging.Debug1_1 == true && BrickNumber != 1)
        {
            BrickNumber -= 1;
        }
      }


      //BrickNumber = BrickRandomNumb;

      if(CurrentBrickLimits[BrickNumber] == BrickLimits[BrickNumber])
      {
        //print("BrickLimit REACHED!!!!:" + CurrentBrickLimits[BrickNumber] + "This BrickNumber" + BrickNumber);
        print("CHANGING BrICK!!!" + BrickNumber);
        PickBrick();
      }

      ActiveBrick.material = BrickMaterials[BrickNumber];

      
      BrickNumbFix();
    }

    public void BrickNumbFix()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CompareArray[0] = Connectors[0].ErrorDetected;
        CompareArray[1] = Connectors[1].ErrorDetected;
        CompareArray[2] = Connectors[2].ErrorDetected;
        CompareArray[3] = Connectors[3].ErrorDetected;
        bool NoErrors = CompareArray.SequenceEqual(CompareArray2); //Jämför en bool array med connectors bools. Ifall ingen av errordetectedboolsen är true så är den här boolen true.

        

        for(int AL = 0; AL < Connectors.Length; AL ++)
        {
            
            if(Connectors[AL].ConnectDetected == true && NoErrors == true)
            {
                PlaceOk = true;
                AllowObject.material = AllowMaterial[0]; // Byter Material så det transparanta blocket på Placern visar ifall man får placera eller inte. Grön = du får || Röd = du får INTE.
            }
            else if (Connectors[0].ConnectDetected == false && Connectors[1].ConnectDetected == false && Connectors[2].ConnectDetected == false && Connectors[3].ConnectDetected == false || Connectors[AL].ErrorDetected == true)
            {
                PlaceOk = false;
              if(Debugging.Debug2!)  print(AL + "This Not Allowing");
                AllowObject.material = AllowMaterial[1]; 
            }
        }
    }
    void OnClick (InputValue value)
    {
if(PlaceOk!)
{
    Instantiate(BrickPrefab[BrickNumber], PlacerObject.transform.position, Quaternion.Euler(rotationVector));
    CurrentBrickLimits[BrickNumber] += 1;
    PickBrick();
    
}
else
{
    print("Nuh uh");
}
    }

    void OnRotate (InputValue value)
    {
        rotationVector.y += 90;
        PlacerObject.transform.rotation = Quaternion.Euler(rotationVector);
        
    }

    void OnChangeBrick (InputValue value)
    {
        PickBrick();
    }
}
