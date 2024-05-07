using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlosterPointsChild : MonoBehaviour
{
    KlosterPoints ParentKloster;

    public int ColNumber;
    // Start is called before the first frame update
    void Start()
    {
        ParentKloster = GetComponentInParent<KlosterPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider Other)
    {
        if(Other.gameObject.tag == "BrickInside")
        {
            ParentKloster.GetPointsBool[ColNumber] = true;
        }

    }
}
