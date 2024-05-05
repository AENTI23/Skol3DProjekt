using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Assertions.Must;
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

    [SerializeField] public Collider otherCollider;

    [SerializeField] public Collider otherCollider2;

    [SerializeField] Collider[] otherColliders;

    [SerializeField] GameObject Parent;

    bool newrotationbool;

    public bool LockResetC;

    public  bool okok;

    public Collider othercollider3;

    public bool isNotpartoftest;

    

   

    



    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.FindWithTag("PlayerController");
        PCscript = PlayerController.GetComponent<PlayersController>();
         ThisRender =  gameObject.GetComponent<MeshRenderer>();

         Parent = transform.parent.gameObject;

   
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(PCscript.ReRunroadbools == true && StopPoints == false || PCscript.Selecting == true && StopPoints == false)
        {
            ReRunTrigger();
    
        }


        if(StopPoints == false && PCscript.Selecting == true && AvailableC == true)
        {
            ThisRender.material = SelectMaterial;
        }
        else if(StopPoints == false)
        {
            ThisRender.material = zeroMaterial;
        }

        if(newrotationbool == true)
        {
            PCscript.ReRunRoadTriggers();
            NewRotationTimer += Time.deltaTime;
            if(NewRotationTimer > 1.8f)
            {
            PCscript.NewRotation();
            newrotationbool = false;
            NewRotationTimer = 0;
            print("NewRot boool");
            }
        }


        if(otherCollider == null && otherCollider2 == null && PCscript.Selecting == true && StopPoints == false)
        {
           // print(Parent.gameObject.transform.position + "cococcaa" + gameObject.name);
            AvailableC = true;
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

        }
    
    }

    void OnTriggerEnter(Collider other) //Denna del behövs inte verkar det som. Ta bort sen när du 100% säker dock.
    {

       if(isNotpartoftest == true)
       {
        
       otherCollider = other;
       
    

        if(otherCollider.gameObject.tag == "RoadPointer" && StopPoints == false && otherCollider.gameObject.layer != PCscript.AntiLayers[PCscript.CurrentPlayer])
        {
          
            AvailableC = true;
            print("AVAILABLE!");
        }
        else if(otherCollider.gameObject.tag == "RoadPointer" && StopPoints == false && otherCollider.gameObject.layer != 15)
        {

            gameObject.layer = otherCollider.gameObject.layer;
          
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                     PCscript.PlayerPoints[0] += 1;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                PCscript.PlayerPoints[1] += 1;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            print("FIRST TIME WORKED");
        }
       
        
       }
    }

        
    void ReRunTrigger()
    {
        if(otherCollider != null) 
        {

         if(otherCollider.gameObject.tag == "RoadPointer" && otherCollider.gameObject.layer != 15 && StopPoints == false)
        {
            print(Parent.gameObject.transform.position + "This worked?" + gameObject.name);
            gameObject.layer = otherCollider.gameObject.layer;
           
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                  PCscript.PlayerPoints[0] += 1;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                  PCscript.PlayerPoints[1] += 1;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            print("Succesfull change");
            

        }
        }
        
        if (otherCollider2 != null)
        {
        if( otherCollider2.gameObject.tag == "RoadPointer" && otherCollider2.gameObject.layer != 15 && StopPoints == false)
        {
            gameObject.layer = otherCollider2.gameObject.layer;
          
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                     PCscript.PlayerPoints[0] += 1;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                 PCscript.PlayerPoints[1] += 1;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            print("Succesfull change");
        }
        }
    

    }
}
