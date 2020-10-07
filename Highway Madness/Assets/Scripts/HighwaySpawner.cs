using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwaySpawner : MonoBehaviour
{
    // Spawnlocation of a highway part
    public GameObject spawnLocation;
    // Highway part
    public GameObject Highway;
    // Time between spawn
 public float spawnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate a first highway part on launch
        InstantiateObject();

        //Start highway part spawnloop
        StartCoroutine(ObjectSpawn());

    }

    // Loop that spawns highway over time.

    IEnumerator ObjectSpawn()
    {
        yield return new WaitForSeconds(spawnSpeed);
        InstantiateObject();
        StartCoroutine(ObjectSpawn());

    }

    // Function that spawns object

    void InstantiateObject()
    {
        Instantiate(Highway, spawnLocation.transform.position, Quaternion.identity);
    }
}
