using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeFixController : MonoBehaviour
{
    public GameObject connect1;
    public GameObject connect2;
    public GameObject connect3;
    public GameObject connect4;

    MouseScript brickcontroller;

    public 



    // Start is called before the first frame update
    void Start()
    {
        brickcontroller = gameObject.GetComponent<MouseScript>();
        connect1.layer = 0;
        connect2.layer = 0;
        connect3.layer = 0;
        connect4.layer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
