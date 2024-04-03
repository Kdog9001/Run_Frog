using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    //Variables
    private GameObject player;

    public bool movingLeft;
    public bool movingRight;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1)
        {
            if (movingLeft)
            {
                player.GetComponent<Controls>().setPHorInput(-1.0f);
            }

            if (movingRight)
            {
                player.GetComponent<Controls>().setPHorInput(1.0f);
            }
        }
        if(Input.touchCount == 0)
        {
            movingLeft = false;
            movingRight = false;
            player.GetComponent<Controls>().setPHorInput(0.0f);
        }

        if (Input.touchCount == 2)
        {
            player.GetComponent<Controls>().setPJumpInput(true);
        }
        else
        {
            player.GetComponent<Controls>().setPJumpInput(false);
        }
        
    }

    private void OnMouseDown()
    {
        if(gameObject.tag == "LI")
        {
            Debug.Log("Touching Left");
            movingLeft = true;
        }
        if (gameObject.tag == "RI")
        {
            Debug.Log("Touching Right");
            movingRight = true;
        }
        /*if(gameObject.tag == "CI")
        {
            Debug.Log("Touching Right");
            player.GetComponent<Controls>().setPJumpInput(true);
        }*/
    }

    void Jump()
    {
        Debug.Log("Jump");
    }
}
