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

    [SerializeField]
    Vector3 ResetPos;

    [SerializeField]
    LayerMask AllowedLayers;

    public bool CancelLayers;

    
    void Start()
    {
       if(CancelLayers == true) Camera.main.eventMask = AllowedLayers;
    }
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
       else
       {
        transform.position = ResetPos;
       }

    }



}
