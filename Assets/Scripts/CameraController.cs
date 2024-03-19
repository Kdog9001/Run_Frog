using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player = new GameObject();

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 4.5 && player.transform.position.x < 10.0 && player.transform.position.y < 10)//bottom right platform
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (player.transform.position.x > 10)// right wall
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (player.transform.position.x > 4.5 && player.transform.position.x < 10.0 && player.transform.position.y > 10)// top right platform
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (player.transform.position.x < 4.5 && player.transform.position.x > -4.5 && player.transform.position.y > 10)//top platform
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (player.transform.position.x > -10 && player.transform.position.x < -4.5 && player.transform.position.y > 10)//top left platform
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (player.transform.position.x < -10)// left wall
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (player.transform.position.x > -10 && player.transform.position.x < -4.5 && player.transform.position.y < 10)//bottom left platform
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 315);
        }
        else
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
}
