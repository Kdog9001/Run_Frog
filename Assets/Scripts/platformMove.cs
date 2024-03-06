using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    public float speed, totalTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death());
    }

    // Update is called once per frame
    void FixedUpdate()//move in direction
    {
        transform.transform.position += Vector3.forward * Time.deltaTime * speed;
    }
    private IEnumerator Death()//Death timer
    {
        float eTime = 0;
        while (eTime < totalTime)
        {
            eTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

}
