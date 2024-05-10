using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    float timer;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1.5f)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
