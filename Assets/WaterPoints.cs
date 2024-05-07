using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoints : MonoBehaviour
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

    [SerializeField] public Collider Collider1;

    [SerializeField] public Collider Collider2;

    

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
        
        if(PCscript.ReRunroadbools == true && StopPoints == false || PCscript.Selecting == true && StopPoints == false)
        {
            CollisionMethod();
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
            PCscript.ReRunWaterTriggers();
            NewRotationTimer += Time.deltaTime;
            if(NewRotationTimer > 1.5f)
            {
            PCscript.NewRotation();
            newrotationbool = false;
            NewRotationTimer = 0;
            }
        }


        if(Collider1 == null && Collider2 == null && PCscript.Selecting == true && StopPoints == false)
        {
         
            AvailableC = true;
        }
    }

    void OnMouseUp()
    {

        if(PCscript.Selecting == true && AvailableC == true && StopPoints == false)
        {
            PCscript.GivePointWater();
            gameObject.layer = ObjectLayer[PCscript.CurrentPlayer];
          ThisRender.material = ObjectMaterial[PCscript.CurrentPlayer];
          StopPoints = true;
          newrotationbool = true;

        }
    
    }

    void CollisionMethod()
    {
        if(Collider1 != null) 
        {

         if(Collider1.gameObject.tag == "WaterPointer" && Collider1.gameObject.layer != 15 && StopPoints == false)
        {
            gameObject.layer = Collider1.gameObject.layer;
           
             if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                     PCscript.PlayerPoints[0] += 2;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                 PCscript.PlayerPoints[1] += 2;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            else if (gameObject.layer == 18)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[2];
                 PCscript.PlayerPoints[2] += 2;
                   PCscript.PlayerPointsUI[2].text = PCscript.PlayerPoints[2].ToString();
            }
            else if (gameObject.layer == 19)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[3];
                 PCscript.PlayerPoints[3] += 2;
                   PCscript.PlayerPointsUI[3].text = PCscript.PlayerPoints[3].ToString();
            }
       
            

        }
        }
        
        if (Collider2 != null)
        {
        if( Collider2.gameObject.tag == "WaterPointer" && Collider2.gameObject.layer != 15 && StopPoints == false)
        {
            gameObject.layer = Collider2.gameObject.layer;
          
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                     PCscript.PlayerPoints[0] += 2;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                 PCscript.PlayerPoints[1] += 2;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            else if (gameObject.layer == 18)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[2];
                 PCscript.PlayerPoints[2] += 2;
                   PCscript.PlayerPointsUI[2].text = PCscript.PlayerPoints[2].ToString();
            }
            else if (gameObject.layer == 19)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[3];
                 PCscript.PlayerPoints[3] += 2;
                   PCscript.PlayerPointsUI[3].text = PCscript.PlayerPoints[3].ToString();
            }
    
        }
        }
    

    }
}
