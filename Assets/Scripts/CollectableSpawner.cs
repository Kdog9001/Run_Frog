using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour

{
    [SerializeField]
    private GameObject fly;
    private GameObject player;
    private platformManager platM;
    [SerializeField]
    private bool flySpawned;
    private Vector3[] spawnPoints, positionArray;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        platM = GameObject.Find("SpawnManager").GetComponent<platformManager>();
        flySpawned = false;
        positionArray = platM.getPosArray();
        spawnPoints = platM.getStartArray();
        StartCoroutine(RandoTime());
    }
    /* Spawn a fly at a random pos around the player
     * and a semi inconsistant time
     */

    // Update is called once per frame
    private void spawnFly() 
    {
        Vector3 point=Vector3.zero;
        Vector3 angle= Vector3.zero;
        int temp = Random.Range(0, 24);
        switch (temp)
        {
           case 0: point = spawnPoints[0]; angle = positionArray[0]; break;
           case 1: point = spawnPoints[1]; angle = positionArray[0]; break;
           case 2: point = spawnPoints[2]; angle = positionArray[0]; break;
           case 3: point = spawnPoints[3]; angle = positionArray[1]; break;
           case 4: point = spawnPoints[4]; angle = positionArray[1]; break;
           case 5: point = spawnPoints[5]; angle = positionArray[1]; break;
           case 6: point = spawnPoints[6]; angle = positionArray[2]; break;
           case 7: point = spawnPoints[7]; angle = positionArray[2]; break;
           case 8: point = spawnPoints[8]; angle = positionArray[2]; break;
           case 9: point = spawnPoints[9]; angle = positionArray[3]; break;
           case 10: point = spawnPoints[10]; angle = positionArray[3]; break;
           case 11: point = spawnPoints[11]; angle = positionArray[3]; break;
           case 12: point = spawnPoints[12]; angle = positionArray[4]; break;
           case 13: point = spawnPoints[13]; angle = positionArray[4]; break;
           case 14: point = spawnPoints[14]; angle = positionArray[4]; break;
            case 15: point = spawnPoints[15]; angle = positionArray[5]; break;
            case 16: point = spawnPoints[16]; angle = positionArray[5]; break;
            case 17: point = spawnPoints[17]; angle = positionArray[5]; break;
            case 18: point = spawnPoints[18]; angle = positionArray[6]; break;
            case 19: point = spawnPoints[19]; angle = positionArray[6]; break;
            case 20: point = spawnPoints[20]; angle = positionArray[6]; break;
            case 21: point = spawnPoints[21]; angle = positionArray[7]; break;
            case 22: point = spawnPoints[22]; angle = positionArray[7]; break;
            case 23: point = spawnPoints[23]; angle = positionArray[7]; break;
        }
        GameObject sly = Instantiate(fly, point, Quaternion.Euler(angle));
        sly.transform.GetChild(0).GetComponent<platformMove>().setSpeed(platM.GetSpeed());
        sly.transform.GetChild(0).GetComponent<platformMove>().setTime(platM.GetPTime());
    }
    private void Update()
    {
        if(!flySpawned) 
        {
            flySpawned = true;
            spawnFly();
            StartCoroutine(RandoTime());
        }
    }
    private IEnumerator RandoTime()//Death timer
    {
        float rTime= Random.Range(2,6.0f);
        float eTime = 0;
        while (eTime < rTime)
        {
            eTime += Time.deltaTime;
            yield return null;
        }
        flySpawned = false;
    }
    private Vector3 playerPos()
    {
        return player.transform.position;
    }
    private Quaternion playerRot()
    {
        return player.transform.rotation;
    }
}
