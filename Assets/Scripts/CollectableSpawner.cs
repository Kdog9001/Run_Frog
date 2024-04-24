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
    // Start is called before the first frame update
    void Start()
    {
        flySpawned = false;
        StartCoroutine(RandoTime());
        player = GameObject.Find("Player");
        platM = GameObject.Find("SpawnManager").GetComponent<platformManager>();
    }
    /* Spawn a fly at a random pos around the player
     * and a semi inconsistant time
     */

    // Update is called once per frame
    private void spawnFly(Vector3 point, Quaternion angle) 
    {
        GameObject sly = Instantiate(fly, point, angle);
        sly.GetComponent<platformMove>().setSpeed(platM.GetSpeed());
        sly.GetComponent<platformMove>().setTime(platM.GetPTime());
    }
    private void Update()
    {
        if(!flySpawned) 
        {
            flySpawned = true;
            spawnFly(playerPos(), playerRot());
            StartCoroutine(RandoTime());
        }
    }
    private IEnumerator RandoTime()//Death timer
    {
        float rTime= Random.Range(1.0f,3.0f);
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
