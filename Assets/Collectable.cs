using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    private Score uSettings;
    void Start()
    {
        uSettings=GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")// collison check for objects taged logs to jump again
        {
            uSettings.AddCScore();
            other.GetComponent<Controls>().CollectSound();
            Destroy(gameObject);
        }
    }
}
