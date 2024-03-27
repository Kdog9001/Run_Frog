using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private bool alive;

    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.Find("Player");
        alive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive)
        {


            switch (player.GetComponent<Controls>().getGarVNum())//rotate player and camera
            {
                case 1: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0); player.transform.rotation = Quaternion.Euler(0, 0, 0); break;
                case 2: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 45); player.transform.rotation = Quaternion.Euler(0, 0, 45); break;
                case 3: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 90); player.transform.rotation = Quaternion.Euler(0, 0, 90); break;
                case 4: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 135); player.transform.rotation = Quaternion.Euler(0, 0, 135); break;
                case 5: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180); player.transform.rotation = Quaternion.Euler(0, 0, 180); break;
                case 6: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 225); player.transform.rotation = Quaternion.Euler(0, 0, 225); break;
                case 7: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 270); player.transform.rotation = Quaternion.Euler(0, 0, 270); break;
                case 8: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 315); player.transform.rotation = Quaternion.Euler(0, 0, 315); break;
            }
        }
       
    }
    public void updatePlayerState()
    {
        alive = false;
    }
}
