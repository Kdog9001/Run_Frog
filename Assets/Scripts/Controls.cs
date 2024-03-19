using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float jumpAmount = 2.5f;
    public bool jumping = false;
    public int multi = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 Movement = new Vector3(multi*Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Movement * speed * Time.deltaTime;
        //starting rotation
        if (transform.position.y > 15.1)
        {
            //Movement = Vector3(-Input.GetAxis("Horizontal"), 0, 0);
            multi = -1;
        } else
            //Movement = Vector3(Input.GetAxis("Horizontal"), 0, 0);
        multi = 1;
        /*if (transform.position.x > 10 && Input.GetKey(KeyCode.A))//rightwall
        {
            rb.velocity = transform.up * speed;
        }
        if (transform.position.x > 10 && Input.GetKey(KeyCode.D))//rightwall
        {
            rb.velocity = -transform.up * speed;
        }
        if (transform.position.x < 10 && Input.GetKey(KeyCode.D))//leftwall
        {
            rb.velocity = transform.up * speed;
        }
        if (transform.position.x < 10 && Input.GetKey(KeyCode.A))//leftwall
        {
            rb.velocity = -transform.up * speed;
        }*/



        jump();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping==false && transform.position.y < 10)
        {
            StartCoroutine(SingleJumpUp());
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false && transform.position.x < -4.5)
        {
            StartCoroutine(SingleJumpRight());

        }

    }

    IEnumerator SingleJumpUp()
    {
        
        jumping = true;
        rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        yield return new WaitForSeconds(2.0f);
        jumping = false;
    }

    IEnumerator SingleJumpRight()
    {
        jumping = true;
        rb.AddForce(Vector3.right * jumpAmount, ForceMode.Impulse);
        yield return new WaitForSeconds(2.0f);
        jumping = false;
    }
}
