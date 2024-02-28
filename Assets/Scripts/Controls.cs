using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += Movement * speed * Time.deltaTime;\
        //starting rotation
        if (transform.position.x > -4 && transform.position.x <5)
        {
           
        }
        //left platform from starting
        if (transform.position.x > -10 && transform.position.x < -5)
        {

        }

    }
}
