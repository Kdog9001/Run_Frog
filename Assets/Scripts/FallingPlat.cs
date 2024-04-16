using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    private float totalTime = 1;
    private float speed;
    private float fallDelay;
    private bool fall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death(totalTime));
        fall = false;
    }

    // Update is called once per frame
    void FixedUpdate()//move in direction
    {
        transform.transform.position += Vector3.forward * Time.deltaTime * speed;
        if (fall)
        {
            Destroy(gameObject);
        }

    }
    private IEnumerator Death(float ttOtalTime)//Death timer
    {
        float eTime = 0;
        while (eTime < ttOtalTime)
        {
            eTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void setTime(float newtime)
    {
        totalTime = newtime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            collision.gameObject.GetComponent<Controls>().CrackSound();
            Invoke("Fall", fallDelay);
        }
    }
    private void Fall()
    {
        fall = true;
    }
}
