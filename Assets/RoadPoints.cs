using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadPoints : MonoBehaviour
{

    [SerializeField] GameObject PlayerController;

    [SerializeField] bool isStartBrick;
    PlayersController PCscript;

    [SerializeField] bool StopPoints;

    [SerializeField] bool AvailableC;

    [SerializeField] int[] ObjectLayer;

    [SerializeField] Material[] ObjectMaterial;

    [SerializeField] Material SelectMaterial;

    [SerializeField] Material zeroMaterial;

    [SerializeField] MeshRenderer ThisRender;

    [SerializeField] float NewRotationTimer;

    [SerializeField] Collider otherCollider;

    bool newrotationbool;



    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.FindWithTag("PlayerController");
        PCscript = PlayerController.GetComponent<PlayersController>();
         ThisRender =  gameObject.GetComponent<MeshRenderer>();
   
    }

    // Update is called once per frame
    void Update()
    {
        if(PCscript.ReRunroadbools == true)
        {
            ReRunTrigger();
        }

        if(StopPoints == false && PCscript.Selecting == true)
        {
            ThisRender.material = SelectMaterial;
        }
        else if(StopPoints == false)
        {
            ThisRender.material = zeroMaterial;
        }

        if(newrotationbool == true)
        {
            NewRotationTimer += Time.deltaTime;
            if(NewRotationTimer > 3)
            {
            PCscript.NewRotation();
            newrotationbool = false;
            print("NewRot boool");
            }
        }
    }

    void OnMouseUp()
    {

        if(PCscript.Selecting == true && AvailableC == true && StopPoints == false)//bool som blir positiv ifall ontriggerenter godkänner??)
        {
           // PCscript.NewRotation();
            PCscript.GivePointRoad();
            gameObject.layer = ObjectLayer[PCscript.CurrentPlayer];
          ThisRender.material = ObjectMaterial[PCscript.CurrentPlayer];
          StopPoints = true;
          
          newrotationbool = true;

            //Succesfull placering, ny rotation, ge poäng, stop points, ändra material och lager.

            //exempel 
        }
        print("Hovering");
    }

    void OnTriggerEnter(Collider other)
    {
        otherCollider = other;
      

        if(other.gameObject.tag == "RoadPointer" && StopPoints == false && other.gameObject.layer != PCscript.AntiLayers[PCscript.CurrentPlayer])
        {
            /*
            gameObject.layer = ObjectLayer[PCscript.CurrentPlayer];
          ThisRender.material = ObjectMaterial[PCscript.CurrentPlayer];
            PCscript.GivePointRoad();
            PCscript.NewRotation();
            */

           // StopPoints = true;
            AvailableC = true;
            print("AVAILABLE!");
        }
        else if(other.gameObject.tag == "RoadPointer" && other.gameObject.layer == PCscript.AntiLayers[PCscript.CurrentPlayer]) //&& StopPoints == false
        {
            gameObject.layer = other.gameObject.layer;
            if (gameObject.layer == 13)
            {
                  ThisRender.material = ObjectMaterial[0];
            }
            else if (gameObject.layer == 14)
            {
                ThisRender.material = ObjectMaterial[1];
            }
           // PCscript.NewRotation();
            //lägg till poäng för den som faktiskt äger vägen.

        }
    }

    void ReRunTrigger()
    {
        if(otherCollider.gameObject.tag == "RoadPointer" && otherCollider.gameObject.layer == PCscript.AntiLayers[PCscript.CurrentPlayer])
        {
            gameObject.layer = otherCollider.gameObject.layer;
            if (gameObject.layer == 13)
            {
                  ThisRender.material = ObjectMaterial[0];
            }
            else if (gameObject.layer == 14)
            {
                ThisRender.material = ObjectMaterial[1];
            }

        }

    }
}
