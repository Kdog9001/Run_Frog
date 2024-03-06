using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float jumpAmount = 5;
    public bool jumping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Movement * speed * Time.deltaTime;
        //starting rotation
        if (transform.position.x > -4 && transform.position.x <5)
        {
           
        }
        //left platform from starting
        if (transform.position.x > -10 && transform.position.x < -5)
        {

        }
        jump();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping==false)
        {
            StartCoroutine(SingleJump());
            
        }
        
    }

    IEnumerator SingleJump()
    {
        
        jumping = true;
        rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        yield return new WaitForSeconds(2.0f);
        jumping = false;
    }
}
