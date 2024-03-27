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
    [SerializeField]
    public int index = 1;
    [SerializeField]
    private int nextPos,curPos;
    [SerializeField]
    private float grav,gravCooldown,jumpGrav,startDelay;
    private bool gravS, start;
    private GameObject me;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        me = GameObject.Find("Player");
        gravS = false;
        start = true;
        StartCoroutine(Death2());
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {


            switch (curPos)
            {
                case 1:
                    Vector3 Movement = new Vector3(multi * Input.GetAxis("Horizontal"), grav, 0);
                    transform.position += Movement * speed * Time.deltaTime;
                    break;
                case 2:
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        Vector3 Movement2 = new Vector3((Input.GetAxis("Horizontal") / 2.0f) - grav / 2.0f, (Input.GetAxis("Horizontal") / 2.0f) + grav / 2.0f, 0);
                        transform.position += Movement2 * speed * Time.deltaTime;
                    }
                    else
                    {
                        Vector3 Movement2 = new Vector3((Input.GetAxis("Horizontal") / 2.0f) - grav / 2.0f, (Input.GetAxis("Horizontal") / 2.0f) + grav / 2.0f, 0);
                        transform.position += Movement2 * speed * Time.deltaTime;
                    }
                    break;
                case 3:
                    Vector3 Movement3 = new Vector3(-grav, (Input.GetAxis("Horizontal")), 0);
                    transform.position += Movement3 * speed * Time.deltaTime; break;
                case 4:
                    Vector3 Movement4 = new Vector3(-(Input.GetAxis("Horizontal") / 2.0f) - grav / 2.0f, (Input.GetAxis("Horizontal") / 2.0f) - grav / 2.0f, 0);
                    transform.position += Movement4 * speed * Time.deltaTime;
                    break;
                case 5:
                    Vector3 Movement5 = new Vector3(-Input.GetAxis("Horizontal"), -grav, 0);
                    transform.position += Movement5 * speed * Time.deltaTime; break;
                case 6:
                    Vector3 Movement6 = new Vector3(-(Input.GetAxis("Horizontal") / 2.0f) + grav / 2.0f, -(Input.GetAxis("Horizontal") / 2.0f) - grav / 2.0f, 0);
                    transform.position += Movement6 * speed * Time.deltaTime; break;
                case 7:
                    Vector3 Movement7 = new Vector3(grav, -(Input.GetAxis("Horizontal")), 0);
                    transform.position += Movement7 * speed * Time.deltaTime; break;
                case 8:
                    Vector3 Movement8 = new Vector3((Input.GetAxis("Horizontal") / 2.0f) + grav / 2.0f, -(Input.GetAxis("Horizontal") / 2.0f) + grav / 2.0f, 0);
                    transform.position += Movement8 * speed * Time.deltaTime; break;

            }
        }
        //Vector3 Movement = new Vector3(multi*Input.GetAxis("Horizontal"), 0, 0);
        //transform.position += Movement * speed * Time.deltaTime;
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
        if (Input.GetKeyDown(KeyCode.Space) && jumping==false)
        {
            StartCoroutine(SingleJumpUp());
            
        }
        if (jumping)
        {
            Vector3 tmepV = Vector3.up;
            switch (curPos)
            {
                case 1: tmepV = Vector3.up; break;
                case 2: tmepV = new Vector3(-0.5f, 0.5f, 0); break;
                case 3: tmepV = Vector3.right; break;
                case 4: tmepV = new Vector3(-0.5f, -0.5f, 0); break;
                case 5: tmepV = Vector3.down; break;
                case 6: tmepV = new Vector3(0.5f, -0.5f, 0); break;
                case 7: tmepV = Vector3.left; break;
                case 8: tmepV = new Vector3(0.5f, 0.5f, 0); break;

            }
        }
    }

    IEnumerator SingleJumpUp()
    {
        
        jumping = true;
        Vector3 tmepV = Vector3.up;
        switch (curPos) {
            case 1: tmepV = Vector3.up; break;
            case 2: tmepV = new Vector3(-0.5f, 0.5f, 0); break;
            case 3: tmepV = Vector3.left; break;
            case 4: tmepV = new Vector3(-0.5f, -0.5f, 0); break;
            case 5: tmepV = Vector3.down; break;
            case 6: tmepV = new Vector3(0.5f, -0.5f, 0); break;
            case 7: tmepV = Vector3.right; break;
            case 8: tmepV = new Vector3(0.5f, 0.5f, 0); break;

        }

        float eTime = 0;
        while (eTime < 0.6f)
        {
            transform.position += tmepV * jumpAmount * Time.deltaTime* (0.8f-eTime/2.0f);
            eTime += Time.deltaTime;
            yield return null;
        } 
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gravM")
        {
            nextPos = other.GetComponent<Grav2>().pos;
            updatedGrav();
        }
        if (other.gameObject.tag == "death")
        {
            //death
            GameObject.Find("Canvas").GetComponent<UserSettings>().died();
            GameObject.Find("MainCamera").GetComponent<CameraController>().updatePlayerState();
            Destroy(me);
        }

    }
    private void updatedGrav()
    {
        if (!gravS)
        {


            if (curPos == 8)
            {
                if (nextPos == 1)
                {
                    curPos = 1;
                    gravS = true;
                    StartCoroutine(Death());
                }
                else if (curPos == nextPos)
                {
                    curPos--;
                    gravS = true;
                    StartCoroutine(Death());
                }
            }
            else if(curPos==1)
            {
                if (nextPos == 1)
                {
                    curPos = 8;
                    gravS = true;
                    StartCoroutine(Death());
                }
                else if (curPos < nextPos)
                {
                    curPos++;
                    gravS = true;
                    StartCoroutine(Death());
                }
            }
            else
            {
                if (curPos < nextPos)
                {
                    curPos++;
                    gravS = true;
                    StartCoroutine(Death());
                }
                else if (curPos == nextPos)
                {
                    curPos--;
                    gravS = true;
                    StartCoroutine(Death());
                }
            }
        }
    }
    private IEnumerator Death()//Death timer
    {
        float eTime = 0;
        while (eTime < gravCooldown)
        {
            eTime += Time.deltaTime;
            yield return null;
        }
        gravS = false;
    }
    private IEnumerator Death2()//Death timer
    {
        float eTime = 0;
        while (eTime < startDelay)
        {
            eTime += Time.deltaTime;
            yield return null;
        }
        start = false;
    }
    public int getGarVNum()
    {
        return curPos;
    }
}
