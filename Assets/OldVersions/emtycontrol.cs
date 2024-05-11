using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class emtycontrol : MonoBehaviour
{


    [SerializeField] GameObject bricks;

    [SerializeField] bool StopSpawn;

    [SerializeField] Vector3 SpawnVector1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnVector1.z = -4;
        
    }

    // Update is called once per frame
    void Update()
    {
       SpawnBricks();
    }

    public void SpawnBricks()
    {//z max 5 min -4
    // x max 4
         if(StopSpawn == false)
        {
            Instantiate(bricks,SpawnVector1, Quaternion.identity);
            SpawnVector1.z += 1;
            if(SpawnVector1.z == 5)
            {
                SpawnVector1.x += 1;
                SpawnVector1.z = -4;
            }
            if(SpawnVector1.x > 4)
            {
                StopSpawn = true;
            }
        }

    }
}
