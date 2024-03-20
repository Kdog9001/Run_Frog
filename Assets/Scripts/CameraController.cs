using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (player.GetComponent<Controls>().getGarVNum()){
            case 1: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0); break;
            case 2: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 45); break;
            case 3: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 90); break;
            case 4: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 135); break;
            case 5: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180); break;
            case 6: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 225); break;
            case 7: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 270); break;
            case 8: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 315); break;
        }
       
    }
}
