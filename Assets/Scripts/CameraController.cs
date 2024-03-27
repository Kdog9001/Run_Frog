using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private bool alive;
    private Vector3 endPosition = new Vector3(5, -2, 0);
    private Vector3 startPosition;
    private float desiredDuration = 3f;
    private float elapsedTime;
    public Transform target;
    public float movementTime;
    public float rotationSpeed;
    Vector3 refPos;
    Vector3 refRot;

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

            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            
            switch (player.GetComponent<Controls>().getGarVNum())//rotate player and camera
            {
                case 1: Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0); player.transform.rotation = Quaternion.Euler(0, 0, 0); 
                        //transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete); startPosition = endPosition; 
                        break;//Floor
                case 2: Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 45), rotationSpeed * Time.deltaTime); player.transform.rotation = Quaternion.Euler(0, 0, 45); break;//RightFloor
                case 3: Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), rotationSpeed * Time.deltaTime); player.transform.rotation = Quaternion.Euler(0, 0, 90); break;//RightWall
                case 4: Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 135), rotationSpeed * Time.deltaTime); player.transform.rotation = Quaternion.Euler(0, 0, 135); break;//RightRoof
                case 5: Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), rotationSpeed* Time.deltaTime); player.transform.rotation = Quaternion.Euler(0, 0, 180); break;//Roof
                case 6: Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 225), rotationSpeed* Time.deltaTime); player.transform.rotation = Quaternion.Euler(0, 0, 225); break;//LeftRoof
                case 7: Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 270), rotationSpeed* Time.deltaTime); player.transform.rotation = Quaternion.Euler(0, 0, 270); break;//LeftWall
                case 8: Camera.main.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 315), rotationSpeed* Time.deltaTime); player.transform.rotation = Quaternion.Euler(0, 0, 315); break;//LeftFloor
            }
        }
       
    }
    public void updatePlayerState()
    {
        alive = false;
    }
}
