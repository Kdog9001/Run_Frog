using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    float percent = 0.0f;
    private bool positive;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        times();
        //float dist = (cam.transform.position.x * parallaxEffect);//cam never moves so time
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
    private void times()
    {


        if (percent == 0)
        {
            positive = true;
        }
        else if (percent == 1)
        {
            positive = false;
        }
        if (positive)
        {
            percent = percent + 0.001f;
        }
        else
        {
            percent = percent - 0.001f;
        }

    }
}
