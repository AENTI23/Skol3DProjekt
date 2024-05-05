using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPoints : MonoBehaviour
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

    [SerializeField] GameObject SelectDisplay;

    [SerializeField] MeshRenderer DisplayRender;

    [SerializeField] Material[] DisplayMaterial;

    bool newrotationbool;


    // Start is called before the first frame update
    void Start()
    {
        SelectDisplay = transform.GetChild(0).gameObject;
        PlayerController = GameObject.FindWithTag("PlayerController");
        PCscript = PlayerController.GetComponent<PlayersController>();
         ThisRender = gameObject.GetComponent<MeshRenderer>();
         DisplayRender = SelectDisplay.GetComponent<MeshRenderer>();
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
            SelectDisplay.SetActive(true);
        }
        else if(StopPoints == false)
        {
            ThisRender.material = zeroMaterial;
            SelectDisplay.SetActive(false);
        }
       

        if(newrotationbool == true)
        {
            PCscript.ReRunCityTriggers();
            NewRotationTimer += Time.deltaTime;
            if(NewRotationTimer > 1.8f)
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
            PCscript.GivePointCity();
            gameObject.layer = ObjectLayer[PCscript.CurrentPlayer];
          ThisRender.material = ObjectMaterial[PCscript.CurrentPlayer];
          DisplayRender.material = DisplayMaterial[PCscript.CurrentPlayer];
          StopPoints = true;
          newrotationbool = true;
          SelectDisplay.SetActive(true);

        }
    
    }

 
    void CollisionMethod()
    {
        if(Collider1 != null) 
        {

         if(Collider1.gameObject.tag == "CityPointer" && Collider1.gameObject.layer != 15 && StopPoints == false)
        {
            //print(Parent.gameObject.transform.position + "This worked?" + gameObject.name);
            gameObject.layer = Collider1.gameObject.layer;
           
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                  DisplayRender.material = DisplayMaterial[0];
                  PCscript.PlayerPoints[0] += 2;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
                  SelectDisplay.SetActive(true);
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                 DisplayRender.material = DisplayMaterial[1];
                  PCscript.PlayerPoints[1] += 2;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
                   SelectDisplay.SetActive(true);
            }
       
            

        }
        }
        
        if (Collider2 != null)
        {
        if( Collider2.gameObject.tag == "CityPointer" && Collider2.gameObject.layer != 15 && StopPoints == false)
        {
            gameObject.layer = Collider2.gameObject.layer;
          
           
            if (gameObject.layer == 13)
            {
                 StopPoints = true;
                  ThisRender.material = ObjectMaterial[0];
                   DisplayRender.material = DisplayMaterial[0];
                     PCscript.PlayerPoints[0] += 2;
                  PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
                  SelectDisplay.SetActive(true);
            }
            else if (gameObject.layer == 14)
            {
                 StopPoints = true;
                ThisRender.material = ObjectMaterial[1];
                 DisplayRender.material = DisplayMaterial[1];
                 PCscript.PlayerPoints[1] += 2;
                   PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
                   SelectDisplay.SetActive(true);
            }
        }
        }
    

    }
}
