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

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool playerAlive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive)
        {
            //Jump when two fingers are tapped
            /*if (Input.touchCount == 2)
            {
                player.GetComponent<Controls>().setPJumpInput(true);
            }*/
            //Left and Right Movement
            if (Input.touchCount == 1)
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
            //Stops movement when nothing is being touched
            else if (Input.touchCount == 0)
            {
                movingLeft = false;
                movingRight = false;
                player.GetComponent<Controls>().setPHorInput(0.0f);
                player.GetComponent<Controls>().setPJumpInput(false);
            }


            //JUMPS WHEN SWIPING UP
            //Gets first touch position
            /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            //Gets touch position after swipe
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                if (endTouchPosition.y > startTouchPosition.y + 3)
                {
                    player.GetComponent<Controls>().setPJumpInput(true);
                }
                else
                {
                    player.GetComponent<Controls>().setPJumpInput(false);
                }
            }
            */
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

        if (gameObject.tag != "LI" && gameObject.tag != "RI")
        {
            player.GetComponent<Controls>().setPJumpInput(true);
        }
    }
    public void Dead()
    {
        playerAlive = false;
    }
}
