using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CurrentBrickUIController : MonoBehaviour
{
    public MouseScript brickscript;

    public Texture[] bricktexts;

    public RawImage thisima;


    // Start is called before the first frame update
    void Start()
    {
       thisima = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        thisima.texture = bricktexts[brickscript.BrickNumber];
    }
}
