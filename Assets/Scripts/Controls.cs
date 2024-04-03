using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Controls : MonoBehaviour
{
    public float speed, jumpAmount;
    private bool jumping = false, gravS, start;
    private int nextPos,curPos;
    [SerializeField]
    private float grav,gravCooldown,jumpGrav,startDelay,deathDelayT;
    private GameObject me;
    private float setJumpAmount;
    private AudioSource soundMe;
    [SerializeField]
    private AudioClip splash, jumpSound;



    void Start()
    {
        me = GameObject.Find("Player");
        gravS = false;
        start = true;
        curPos = 1;
        StartCoroutine(startTimer());
        setJumpAmount = jumpAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {

            switch (curPos)//each case repreasents a side 1 being the base floor and
                           //counting up by one going right ending with 8 on theleft of the floor
            {
                case 1:
                    Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), grav, 0);//apply the angle to the player input and gravity
                    transform.position += Movement * speed * Time.deltaTime;
                    break;
                case 2:
                    Vector3 Movement2 = new Vector3((Input.GetAxis("Horizontal") / 2.0f) - grav / 2.0f, (Input.GetAxis("Horizontal") / 2.0f) + grav / 2.0f, 0);
                    transform.position += Movement2 * speed * Time.deltaTime;
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
    public void horInput()
    {

    }
    public void jumpInput()
    {

    }
    private void soundDeath()
    {
        soundMe.clip = splash;
        soundMe.Play();
    }
    private void soundJump()
    {
        soundMe.clip = jumpSound;
        soundMe.Play();
    }
    private void FixedUpdate()
    {
        if (jumping)//find the angle and applie jump force and jump grav to the angle
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
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping==false)
        {
            jumping = true;
            soundJump();
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gravM")//loook for gravManagers triggeres
        {
            if (jumping)
            {
                //check for hor input
                //check for the correct directional input to match with change
                nextPos = other.GetComponent<Grav2>().pos;
                if (curPos == 8 && nextPos == 1 && Input.GetAxis("Horizontal") > 0.0f)
                {
                    updatedGrav();
                }
                else if(nextPos > curPos && Input.GetAxis("Horizontal") > 0.0f)
                {
                    updatedGrav();
                }
                else if (nextPos== curPos && Input.GetAxis("Horizontal") < 0.0f)
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
        if (other.gameObject.tag == "death")//look for kill boxes
        {
            //death
            soundDeath();
            Invoke("deathDelay", deathDelayT);
        }

    }
    private void deathDelay()
    {
        GameObject.Find("Canvas").GetComponent<UserSettings>().died();
        GameObject.Find("Main Camera").GetComponent<CameraController>().updatePlayerState();
        GameObject.Find("PlatformSpawnManager").GetComponent<platformManager>().restart();
        Destroy(me);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Log")// collison check for objects taged logs to jump again
        {
            if (jumping == true)
            {
                jumpAmount = setJumpAmount;
                jumping = false;
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
    private IEnumerator startTimer()//Start timer
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
