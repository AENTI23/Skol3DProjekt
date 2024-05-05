using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadpointsChild : MonoBehaviour
{
    RoadPoints parentScript;

    public bool firstcollider;
      [SerializeField] GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<RoadPoints>();
        Parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.layer = Parent.layer;
    }

    void OnTriggerEnter(Collider OtherCol)
    {
        if(firstcollider == true)
        {

        parentScript.otherCollider = OtherCol;
        }
        else
        {
            parentScript.otherCollider2 = OtherCol;
        }
    }
}
