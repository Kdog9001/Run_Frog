using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
