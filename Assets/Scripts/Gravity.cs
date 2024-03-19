using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject frog = new GameObject();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frog.transform.position.x > 4.5 && frog.transform.position.x < 10.0 && frog.transform.position.y < 10)//bottom right platform
        {
            
            Physics.gravity = new Vector3(10.0F, -10.0F, 0);
        }
        else if (frog.transform.position.x > 10)// right wall
        {
            
            Physics.gravity = new Vector3(10.0f, 0, 0);
        }
        else if (frog.transform.position.x > 4.5 && frog.transform.position.x < 10.0 && frog.transform.position.y > 10)// top right platform
        {
            Physics.gravity = new Vector3(10.0F, 10.0F, 0);
        }
        else if (frog.transform.position.x < 4.5 && frog.transform.position.x > -4.5 && frog.transform.position.y > 10)//top platform
        {
            Physics.gravity = new Vector3(0, 10.0F, 0);
        }
        else if (frog.transform.position.x > -10 && frog.transform.position.x < -4.5 && frog.transform.position.y > 10)//top left platform
        {
            Physics.gravity = new Vector3(-10.0f, 10.0F, 0);
        }
        else if (frog.transform.position.x < -10)// left wall
        {
            Physics.gravity = new Vector3(-10.0f, 0, 0);
        }
        else if (frog.transform.position.x > -10 && frog.transform.position.x < -4.5 && frog.transform.position.y < 10)//bottom left platform
        {
            Physics.gravity = new Vector3(-10.0f, -10.0F, 0);
        }
        else
            Physics.gravity = new Vector3(0, -10.0F, 0);
    }
}
