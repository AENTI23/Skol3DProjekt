using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class KlosterPoints : MonoBehaviour
{

    PlayersController PCscript;
    [SerializeField] bool StopPoints;

    [SerializeField] bool StopClaim;

     [SerializeField] int[] ObjectLayer;
    [SerializeField] Material[] RoofMaterial;

    [SerializeField] Material[] WallMaterial;
    [SerializeField] Material SelectMaterial;
    [SerializeField] Material zeroMaterial;
    [SerializeField] MeshRenderer KlosterRoofRender;
    [SerializeField] MeshRenderer KlosterWallsRender;
    [SerializeField] public bool[] GetPointsBool;

    [SerializeField] bool truebool;

    [SerializeField] GameObject[] Colliders;


    // Start is called before the first frame update
    void Start()
    {
         KlosterRoofRender = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
         KlosterWallsRender = transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
         PCscript = GameObject.FindWithTag("PlayerController").GetComponent<PlayersController>();
          Colliders[0] = transform.GetChild(2).gameObject;
          Colliders[1] = transform.GetChild(3).gameObject;
          Colliders[2] = transform.GetChild(4).gameObject;
          Colliders[3] = transform.GetChild(5).gameObject;
          Colliders[4] = transform.GetChild(6).gameObject;
          Colliders[5] = transform.GetChild(7).gameObject;
          Colliders[6] = transform.GetChild(8).gameObject;
          Colliders[7] = transform.GetChild(9).gameObject;
   
    }

    // Update is called once per frame
    void Update()
    {
        if(PCscript.Selecting == true && StopClaim == false)
        {
            KlosterRoofRender.material = SelectMaterial;
            Colliders[0].SetActive(false);
            Colliders[1].SetActive(false);
            Colliders[2].SetActive(false);
            Colliders[3].SetActive(false);
            Colliders[4].SetActive(false);
            Colliders[5].SetActive(false);
            Colliders[6].SetActive(false);
            Colliders[7].SetActive(false);

        }
        else if(StopClaim == false && StopPoints == false)
        {
            KlosterRoofRender.material = zeroMaterial;

        }

        if(PCscript.Selecting == false && StopPoints == false)
        {
              Colliders[0].SetActive(true); 
            Colliders[1].SetActive(true);
            Colliders[2].SetActive(true);
            Colliders[3].SetActive(true);
            Colliders[4].SetActive(true);
            Colliders[5].SetActive(true);
            Colliders[6].SetActive(true);
            Colliders[7].SetActive(true);
        }



       if(GetPointsBool.All (truebool => truebool) && StopClaim == true && StopPoints == false) 
       {
        StopPoints = true;
       if(gameObject.layer == 13)
       {
            PCscript.PlayerPoints[0] += 8;
            PCscript.PlayerPointsUI[0].text = PCscript.PlayerPoints[0].ToString();
            KlosterRoofRender.material = RoofMaterial[0];
            KlosterWallsRender.material = WallMaterial[0];
       }
       else if(gameObject.layer == 14)
       {
            PCscript.PlayerPoints[1] += 8;
            PCscript.PlayerPointsUI[1].text = PCscript.PlayerPoints[1].ToString();
            KlosterRoofRender.material = RoofMaterial[1];
            KlosterWallsRender.material = WallMaterial[1];
       }
       else if(gameObject.layer == 18)
       {
            PCscript.PlayerPoints[2] += 8;
            PCscript.PlayerPointsUI[2].text = PCscript.PlayerPoints[2].ToString();
            KlosterRoofRender.material = RoofMaterial[2];
            KlosterWallsRender.material = WallMaterial[2];
       }
       else if(gameObject.layer == 19)
       {
            PCscript.PlayerPoints[3] += 8;
            PCscript.PlayerPointsUI[3].text = PCscript.PlayerPoints[3].ToString();
            KlosterRoofRender.material = RoofMaterial[3];
            KlosterWallsRender.material = WallMaterial[3];
       }
        
       }
    }

    void OnMouseUp()
    {
        if(StopClaim == false && PCscript.Selecting == true && PCscript.PlayerPlacers[PCscript.CurrentPlayer] != 0)
        {
            StopClaim = true;
            gameObject.layer = ObjectLayer[PCscript.CurrentPlayer];
            KlosterRoofRender.material = RoofMaterial[PCscript.CurrentPlayer];
            KlosterWallsRender.material = WallMaterial[PCscript.CurrentPlayer];
            PCscript.PlayerPlacers[PCscript.CurrentPlayer] -= 1;
            PCscript.NewRotation();
        }
    }
}
