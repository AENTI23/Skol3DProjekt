using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    GameObject thisobject;

    public bool Changemode;

    public Vector3 DownVector;

    public Vector3 UpVector;

    public Vector3 LeftVector;

    public Vector3 RightVector;

    public Vector3 NorthVector;

    public Vector3 SouthVector;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnvector = new Vector3(0, 7, 0);
        gameObject.transform.position = spawnvector;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCameraMode (InputValue input)
    {
        if(Changemode == false)
        {

        Changemode = true;
        }
        else
        {
            Changemode = false;
        }

    }

    void OnDown (InputValue input)
    {
         if(Changemode == true && gameObject.transform.position.y > 3)
        {
              gameObject.transform.position -= DownVector;
        }
    }

    void OnUp (InputValue input)
    {
        if(Changemode == true && gameObject.transform.position.y < 20)
        {
             gameObject.transform.position += UpVector;
        }
    }

    void OnLeft(InputValue input)
    {
         if(Changemode == true && gameObject.transform.position.x > -42.2f)
        {
             gameObject.transform.position -= LeftVector;
        }

    }

    void OnRight(InputValue input)
    {
        if(Changemode == true && gameObject.transform.position.y < 42.2f)
        {
             gameObject.transform.position += RightVector;
        }

    }

    void OnNorth(InputValue input)
    {
        if(Changemode == true && gameObject.transform.position.z < 42.2f)
        {
             gameObject.transform.position += NorthVector;
        }

    }

    void OnSouth(InputValue input)
    {
        if(Changemode == true && gameObject.transform.position.z > -42.2f)
        {
             gameObject.transform.position -= SouthVector;
        }

    }
}
