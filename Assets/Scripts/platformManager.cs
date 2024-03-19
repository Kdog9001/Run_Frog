using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    [SerializeField]
    private Vector3[] spawnPoints;
    [SerializeField]
    private float StartSpeed, StartDelay, intervalTime;
    [SerializeField]
    private GameObject platform;
    private Vector3 a1 = new Vector3 (0,0,0), a2 = new Vector3(0, 0, 45), a3 = new Vector3(0, 0, 90), a4 = new Vector3(0, 0, 135), a5 = new Vector3(0, 0, 180), a6 = new Vector3(0, 0, 225), a7 = new Vector3(0, 0, 270), a8 = new Vector3(0, 0, 315);

    private void Start()
    {
        // array of spawn points, and rotations 
        // start wiht a strecth of platforms
        // start with simple random
        // logic later(is jump possible
        // 
        InvokeRepeating("spawnProtect", 0f, intervalTime);
        StartCoroutine(protect());

    }
    private IEnumerator protect()//Death timer
    {
        float eTime = 0;
        while (eTime < StartDelay)
        {
            eTime += Time.deltaTime;
            yield return null;
        }
        CancelInvoke();
        InvokeRepeating("spawn", 0f, intervalTime);
    }
    private IEnumerator spawnPlatform(Vector3 point,Vector3 angle)
    {
        GameObject plat = Instantiate(platform, point, Quaternion.Euler(angle));
        plat.GetComponent<platformMove>().setSpeed(StartSpeed);
        yield return null;
    }
    private int Rando()
    {
       int k= Random.Range(1, 4);
        return k;
    }
    private void spawn()//spawn platform with a chance of not
    {
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[0], a1));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[1], a1));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[2], a1));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[3], a2));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[4], a2));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[5], a2));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[6], a3));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[7], a3));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[8], a3));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[9], a4));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[10], a4));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[11], a4));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[12], a5));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[13], a5));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[14], a5));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[15], a6));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[16], a6));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[17], a6));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[18], a7));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[19], a7));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[20], a7));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[21], a8));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[22], a8));
        }
        if (Rando() != 3)
        {
            StartCoroutine(spawnPlatform(spawnPoints[23], a8));
        }
    }
        private void spawnProtect()//spawn platform 
        {
           
                StartCoroutine(spawnPlatform(spawnPoints[0], a1));
            
            
                StartCoroutine(spawnPlatform(spawnPoints[1], a1));
           
                StartCoroutine(spawnPlatform(spawnPoints[2], a1));
            
                StartCoroutine(spawnPlatform(spawnPoints[3], a2));
            
                StartCoroutine(spawnPlatform(spawnPoints[4], a2));
            
                StartCoroutine(spawnPlatform(spawnPoints[5], a2));
            
                StartCoroutine(spawnPlatform(spawnPoints[6], a3));
            
                StartCoroutine(spawnPlatform(spawnPoints[7], a3));
            
                StartCoroutine(spawnPlatform(spawnPoints[8], a3));
            
                StartCoroutine(spawnPlatform(spawnPoints[9], a4));
           
                StartCoroutine(spawnPlatform(spawnPoints[10], a4));
            
                StartCoroutine(spawnPlatform(spawnPoints[11], a4));
            
                StartCoroutine(spawnPlatform(spawnPoints[12], a5));
            
                StartCoroutine(spawnPlatform(spawnPoints[13], a5));
            
                StartCoroutine(spawnPlatform(spawnPoints[14], a5));
            
                StartCoroutine(spawnPlatform(spawnPoints[15], a6));
            
                StartCoroutine(spawnPlatform(spawnPoints[16], a6));
            
                StartCoroutine(spawnPlatform(spawnPoints[17], a6));
            
                StartCoroutine(spawnPlatform(spawnPoints[18], a7));
            
                StartCoroutine(spawnPlatform(spawnPoints[19], a7));
           
                StartCoroutine(spawnPlatform(spawnPoints[20], a7));
            
            
                StartCoroutine(spawnPlatform(spawnPoints[21], a8));
            
                StartCoroutine(spawnPlatform(spawnPoints[22], a8));
            
            
                StartCoroutine(spawnPlatform(spawnPoints[23], a8));
            
        }
        

    /*
    5.92 1.204 0 
    8.04 3.325 0
    10.165 5.447 0 
    11.373 8.363 0
    11.373 11.363 0
    11.373 14.363 0
    10.183 17.274 0
    8.072 19.383 0
    5.95 21.495 0 
    3.05 22.698 0
    0.05 22.698 0
    -2.95 22.698 0
    -5.83 21.51 0
    -7.954999 19.388 0
    -10.075 17.267 0 
    -11.31 14.33 0
    -11.31 11.33 0
    -11.31 8.33 0
    -5.91 1.2 0
    -8.021 3.308999 0
    -10.143 5.421 0
    */




}
