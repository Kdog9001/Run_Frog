using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    [SerializeField]
    private int chance;
    [SerializeField]
    private Vector3[] spawnPoints;
    [SerializeField]
    private float StartSpeed, StartDelay, intervalTime, platTime, difSpeeedIncreaase;
    [SerializeField]
    private GameObject platform;
    private int spCount,spSide;
    private Vector3[] positionArray = { new Vector3(0, 0, 0), new Vector3(0, 0, 45), new Vector3(0, 0, 90), new Vector3(0, 0, 135), new Vector3(0, 0, 180), new Vector3(0, 0, 225), new Vector3(0, 0, 270), new Vector3(0, 0, 315) };
    private Vector3 a1 = new Vector3 (0,0,0), a2 = new Vector3(0, 0, 45), a3 = new Vector3(0, 0, 90), a4 = new Vector3(0, 0, 135), a5 = new Vector3(0, 0, 180), a6 = new Vector3(0, 0, 225), a7 = new Vector3(0, 0, 270), a8 = new Vector3(0, 0, 315);

    private void Start()
    {
        // array of spawn points, and rotations 
        // start wiht a strecth of platforms
        // start with simple random
        // logic later(is jump possible
        // 
        //InvokeRepeating("spawnProtect", 0f, intervalTime);
        ///StartCoroutine(protect());
        //
        platSetUp(new Vector3(0,0,0));
        GameObject.Find("Score").GetComponent<Score>().StartScore();
        InvokeRepeating("spawn",0.0f, intervalTime);
        InvokeRepeating("increaseDiff", StartDelay, StartDelay);

    }
    public void restart()
    {
        resetTime();

    }
    private IEnumerator spawnPlatform(Vector3 point,Vector3 angle)
    {
        GameObject plat = Instantiate(platform, point, Quaternion.Euler(angle));
        plat.GetComponent<platformMove>().setSpeed(StartSpeed);
        plat.GetComponent<platformMove>().setTime(platTime);
        yield return null;
    }
    
    private int Rando()
    {
       int k= Random.Range(1, chance);
        return k;
    }
    private void spawn()//spawn platform with a chance of not
    {
        for (int i = 0; i < 8; i++)
        {
            spCount = 0;
                
                for (int u = 0; u < 3; u++)
                {
                switch (i)
                {
                    case 0: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[spCount], positionArray[i])); break;
                    case 1: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[3+ spCount], positionArray[i])); break;
                    case 2: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[6 + spCount], positionArray[i])); break;
                    case 3: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[9 + spCount], positionArray[i])); break;
                    case 4: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[12 + spCount], positionArray[i])); break;
                    case 5: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[15 + spCount], positionArray[i])); break;
                    case 6: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[18 + spCount], positionArray[i])); break;
                    case 7: if (Rando() != 3) StartCoroutine(spawnPlatform(spawnPoints[21 + spCount], positionArray[i])); break;
                }
                spCount++;
            }

        }
        
    }
    private void platSetUp(Vector3 offset)
    {
        for (int b = 0; b < 12; b++)
        {
            for (int i = 0; i < 8; i++)
            {
                spCount = 0;

                for (int u = 0; u < 3; u++)
                {
                    switch (i)
                    {
                        case 0:StartCoroutine(spawnPlatform(spawnPoints[spCount] + offset, positionArray[i])); break;
                        case 1:StartCoroutine(spawnPlatform(spawnPoints[3 + spCount] + offset, positionArray[i])); break;
                        case 2:StartCoroutine(spawnPlatform(spawnPoints[6 + spCount] + offset, positionArray[i])); break;
                        case 3:StartCoroutine(spawnPlatform(spawnPoints[9 + spCount] + offset, positionArray[i])); break;
                        case 4:StartCoroutine(spawnPlatform(spawnPoints[12 + spCount] + offset, positionArray[i])); break;
                        case 5:StartCoroutine(spawnPlatform(spawnPoints[15 + spCount] + offset, positionArray[i])); break;
                        case 6:StartCoroutine(spawnPlatform(spawnPoints[18 + spCount] + offset, positionArray[i])); break;
                        case 7:StartCoroutine(spawnPlatform(spawnPoints[21 + spCount] + offset, positionArray[i])); break;
                    }
                    spCount++;
                }

            }
            offset = offset - new Vector3(0, 0, 3.0f);
        }
    }
    private void increaseDiff()//test might just look into speeding game up
    {
        //StartSpeed -= difSpeeedIncreaase;
        //float temp = StartSpeed / -3.0f;
        //intervalTime= 1.0f / temp;
        Time.timeScale = Time.timeScale+difSpeeedIncreaase;
    }
    private void resetTime()
    {
        Time.timeScale = 1.0f;
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
