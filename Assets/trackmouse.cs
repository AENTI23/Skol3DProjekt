using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class trackmouse : MonoBehaviour
{
    [SerializeField] private Camera MainCam;
    [SerializeField] LayerMask layerMask;

    [SerializeField] Vector3 pos;

    int storeX;

    int storeY;

    int storeZ;

    [SerializeField]
    Vector3 posfinal;

    void Update ()
    {
        
       Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
       if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
       {
        pos = raycastHit.point;
        storeX = (int)pos.x;
        storeY = (int)pos.y;
        storeZ = (int)pos.z;
        posfinal = new Vector3(storeX, storeY, storeZ);
        transform.position = posfinal;
       }

    }



}
