using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoints : MonoBehaviour
{
    

    [SerializeField] GameObject PlayerController;
    PlayersController PCscript;

    [SerializeField] bool Claimed;

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
        
        if(PCscript.ReRunCollisionsBool == true && Claimed == false || PCscript.Selecting == true && Claimed == false)
        {
            CollisionMethod();
        }
       

        if(Claimed == false && PCscript.Selecting == true && AvailableC == true)
        {
            ThisRender.material = SelectMaterial;
        }
        else if(Claimed == false)
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


        if(Collider1 == null && Collider2 == null && PCscript.Selecting == true && Claimed == false)
        {
         
            AvailableC = true;
        }
    }

    void OnMouseUp()
    {

        if(PCscript.Selecting == true && AvailableC == true && Claimed == false && PCscript.PlayerPlacers[PCscript.CurrentPlayer] != 0)
        {
            PCscript.GivePointWater();
            gameObject.layer = ObjectLayer[PCscript.CurrentPlayer];
          ThisRender.material = ObjectMaterial[PCscript.CurrentPlayer];
          PCscript.PlayerPlacers[PCscript.CurrentPlayer] -= 1;
          Claimed = true;
          newrotationbool = true;
          PCscript.QuickUIfix();
            PCscript.ClaimSound.Play();
                        PCscript.GiveBackPlacers();



        }
    
    }

    void CollisionMethod()
    {
        if(Collider1 != null) 
        {

         if(Collider1.gameObject.tag == "WaterPointer" && Collider1.gameObject.layer != 15 && Claimed == false)
        {
            gameObject.layer = Collider1.gameObject.layer;
           
             if (gameObject.layer == 13)
            {
                 Claimed = true;
                  ThisRender.material = ObjectMaterial[0];
                     PCscript.PlayerPoints[0] += 2;
                    PCscript.CountingPoints[0] += 2;

                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 Claimed = true;
                ThisRender.material = ObjectMaterial[1];
                 PCscript.PlayerPoints[1] += 2;
                 PCscript.CountingPoints[1] += 2;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            else if (gameObject.layer == 18)
            {
                 Claimed = true;
                ThisRender.material = ObjectMaterial[2];
                 PCscript.PlayerPoints[2] += 2;
                 PCscript.CountingPoints[2] += 2;
                   PCscript.PlayerPointsUI[2].text = PCscript.PlayerPoints[2].ToString();
            }
            else if (gameObject.layer == 19)
            {
                 Claimed = true;
                ThisRender.material = ObjectMaterial[3];
                 PCscript.PlayerPoints[3] += 2;
                 PCscript.CountingPoints[3] += 2;
                   PCscript.PlayerPointsUI[3].text = PCscript.PlayerPoints[3].ToString();
            }
       
            

        }
        }
        
        if (Collider2 != null)
        {
        if( Collider2.gameObject.tag == "WaterPointer" && Collider2.gameObject.layer != 15 && Claimed == false)
        {
            gameObject.layer = Collider2.gameObject.layer;
          
           
            if (gameObject.layer == 13)
            {
                 Claimed = true;
                  ThisRender.material = ObjectMaterial[0];
                     PCscript.PlayerPoints[0] += 2;
                     PCscript.CountingPoints[0] += 2;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            }
            else if (gameObject.layer == 14)
            {
                 Claimed = true;
                ThisRender.material = ObjectMaterial[1];
                 PCscript.PlayerPoints[1] += 2;
                 PCscript.CountingPoints[1] += 2;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            }
            else if (gameObject.layer == 18)
            {
                 Claimed = true;
                ThisRender.material = ObjectMaterial[2];
                 PCscript.PlayerPoints[2] += 2;
                 PCscript.CountingPoints[2] += 2;
                   PCscript.PlayerPointsUI[2].text = PCscript.PlayerPoints[2].ToString();
            }
            else if (gameObject.layer == 19)
            {
                 Claimed = true;
                ThisRender.material = ObjectMaterial[3];
                 PCscript.PlayerPoints[3] += 2;
                 PCscript.CountingPoints[3] += 2;
                   PCscript.PlayerPointsUI[3].text = PCscript.PlayerPoints[3].ToString();
            }
    
        }
        }
    

    }
}
