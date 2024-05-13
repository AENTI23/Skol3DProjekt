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
    PlayersController PCscript;

    [SerializeField] bool StopPoints;

    [SerializeField] bool AvailableC;

    [SerializeField] int[] ObjectLayer;

    [SerializeField] Material[] ObjectMaterial;

    [SerializeField] Material SelectMaterial;

    [SerializeField] Material zeroMaterial;

    [SerializeField] MeshRenderer ThisRender;

    [SerializeField] float NewRotationTimer;

    [SerializeField] public Collider Collider;

    [SerializeField] public Collider Collider2;

    [SerializeField] GameObject Parent;

    bool newrotationbool;

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
        
        if(PCscript.ReRunCollisionsBool == true && StopPoints == false || PCscript.Selecting == true && StopPoints == false)
        {
            ReRunCollisions();
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
            PCscript.ReRunCollisions();
            NewRotationTimer += Time.deltaTime;
            if(NewRotationTimer > 0.1f)
            {
            PCscript.NewRotation();
            newrotationbool = false;
            NewRotationTimer = 0;
            }
        }


        if(Collider == null && Collider2 == null && PCscript.Selecting == true && StopPoints == false)
        {
           // print(Parent.gameObject.transform.position + "cococcaa" + gameObject.name);
            AvailableC = true;
        }
    }

    void OnMouseUp()
    {

        if(PCscript.Selecting == true && AvailableC == true && StopPoints == false && PCscript.PlayerPlacers[PCscript.CurrentPlayer] != 0)
        {
            PCscript.GivePoint();
            gameObject.layer = ObjectLayer[PCscript.CurrentPlayer];
          ThisRender.material = ObjectMaterial[PCscript.CurrentPlayer];
          PCscript.PlayerPlacers[PCscript.CurrentPlayer] -= 1;
          PCscript.QuickUIfix();
          StopPoints = true;
          newrotationbool = true;
          PCscript.ClaimSound.Play();
                      PCscript.GiveBackPlacers();



        }
        else
        {

            print("detected but not claim");
        }
        
    
    }

        
    void ReRunCollisions()
    {
        if(Collider != null) 
        {

         if(Collider.gameObject.tag == "RoadPointer" && Collider.gameObject.layer != 15 && StopPoints == false)
        {
            gameObject.layer = Collider.gameObject.layer;
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                  PCscript.PlayerPoints[0] += 1;
                  PCscript.CountingPoints[0] += 1;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                  PCscript.PlayerPoints[1] += 1;
                    PCscript.CountingPoints[1] += 1;

                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            else if (gameObject.layer == 18)
            {
                StopPoints = true;
                ThisRender.material = ObjectMaterial[2];
                  PCscript.PlayerPoints[2] += 1;
                    PCscript.CountingPoints[2] += 1;

                   PCscript.PlayerPointsUI[2].text = PCscript.PlayerPoints[2].ToString();
            }
            else if (gameObject.layer == 19)
            {
                StopPoints = true;
                ThisRender.material = ObjectMaterial[3];
                  PCscript.PlayerPoints[3] += 1;
                    PCscript.CountingPoints[3] += 1;
                   PCscript.PlayerPointsUI[3].text = PCscript.PlayerPoints[3].ToString();
            }
       
            

        }
        }
        
        if (Collider2 != null)
        {
        if( Collider2.gameObject.tag == "RoadPointer" && Collider2.gameObject.layer != 15 && StopPoints == false)
        {
            gameObject.layer = Collider2.gameObject.layer;
          
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                  PCscript.PlayerPoints[0] += 1;
                    PCscript.CountingPoints[0] += 1;

                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                  PCscript.PlayerPoints[1] += 1;
                    PCscript.CountingPoints[1] += 1;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            else if (gameObject.layer == 18)
            {
                StopPoints = true;
                ThisRender.material = ObjectMaterial[2];
                  PCscript.PlayerPoints[2] += 1;
                    PCscript.CountingPoints[2] += 1;
                   PCscript.PlayerPointsUI[2].text = PCscript.PlayerPoints[2].ToString();
            }
            else if (gameObject.layer == 19)
            {
                StopPoints = true;
                ThisRender.material = ObjectMaterial[3];
                  PCscript.PlayerPoints[3] += 1;
                    PCscript.CountingPoints[3] += 1;
                   PCscript.PlayerPointsUI[3].text = PCscript.PlayerPoints[3].ToString();
            }
    
        }
        }
    

    }
}
