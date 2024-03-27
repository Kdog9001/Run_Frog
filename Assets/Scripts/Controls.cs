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
    private int index = 1;
    [SerializeField]
    private int nextPos,curPos;
    [SerializeField]
    private float grav,gravCooldown,jumpGrav,startDelay;
    [SerializeField]
    private float jumpTime;
    private bool gravS, start;
    private GameObject me;
    private float setJumpAmount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        me = GameObject.Find("Player");
        gravS = false;
        start = true;
        StartCoroutine(Death2());
        setJumpAmount = jumpAmount;
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
        jump();
    }
    private void FixedUpdate()
    {
        if (jumping)
        {


            Vector3 tmepV = Vector3.up;
            switch (curPos)
            {
                case 1: tmepV = Vector3.up; break;
                case 2: tmepV = new Vector3(-0.5f, 0.5f, 0); break;
                case 3: tmepV = Vector3.left; break;
                case 4: tmepV = new Vector3(-0.5f, -0.5f, 0); break;
                case 5: tmepV = Vector3.down; break;
                case 6: tmepV = new Vector3(0.5f, -0.5f, 0); break;
                case 7: tmepV = Vector3.right; break;
                case 8: tmepV = new Vector3(0.5f, 0.5f, 0); break;
            }
                transform.position += tmepV * jumpAmount * Time.deltaTime;
                jumpAmount = jumpAmount - ((jumpGrav * jumpGrav) * Time.deltaTime);
                // delta v/ delta t jumpGrav
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping==false)
        {
            jumping = true;


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
        while (jumping)
        {
            transform.position += tmepV *jumpAmount *Time.deltaTime;
            jumpAmount = jumpAmount - ((jumpGrav * jumpGrav) * Time.deltaTime);
            // delta v/ delta t jumpGrav
            eTime += Time.deltaTime;
        }
        yield return null;
        //sets jumping to false
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gravM")
        {
            if (jumping)
            {
                //check for hor input
                nextPos = other.GetComponent<Grav2>().pos;
                if(nextPos > curPos && Input.GetAxis("Horizontal") > 0)
                {
                    updatedGrav();
                }
                else if (curPos==8&& nextPos == 1&&Input.GetAxis("Horizontal") > 0)
                {
                    updatedGrav();
                }
                else if (nextPos< curPos && Input.GetAxis("Horizontal") < 0)
                {
                    updatedGrav();
                }
                else if (curPos==1 && nextPos==8 && Input.GetAxis("Horizontal") < 0)
                {
                    updatedGrav();
                }
            }
            else
            {
                nextPos = other.GetComponent<Grav2>().pos;
                updatedGrav();
            }
        }
        if (other.gameObject.tag == "death")
        {
            //death
            GameObject.Find("Canvas").GetComponent<UserSettings>().died();
            GameObject.Find("Main Camera").GetComponent<CameraController>().updatePlayerState();
            Destroy(me);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Log")
        {
            Debug.Log("lll");
            if (jumping == true)
            {
                jumpAmount = setJumpAmount;
                jumping = false;
                Debug.Log("666");
            }
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
