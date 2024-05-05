using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPointsChild : MonoBehaviour
{
     CityPoints parentScript;

    public bool Child1;

    public bool Child2;

    public bool Child3;

    public bool Child4;
      [SerializeField] GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<CityPoints>();
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
        if(Child1 == true)
        {

        parentScript.Collider1 = OtherCol;
        }
        else if(Child2 == true)
        {
            parentScript.Collider2 = OtherCol;
        }
    }
}
