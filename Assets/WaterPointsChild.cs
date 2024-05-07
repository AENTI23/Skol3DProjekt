using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPointsChild : MonoBehaviour
{
    WaterPoints parentScript;

    public bool Col1;
      [SerializeField] GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<WaterPoints>();
        Parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Parent.layer != 16)
        {
        gameObject.layer = Parent.layer;
        }
    }

    void OnTriggerEnter(Collider OtherCol)
    {
        if(Col1 == true)
        {

        parentScript.Collider1 = OtherCol;
        }
        else
        {
            parentScript.Collider2 = OtherCol;
        }
    }
}
