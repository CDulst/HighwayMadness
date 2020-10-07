using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //List of spawnpoints where enemy could spawn
    public List<GameObject> spawnPoints;
    //Enemy object
    public GameObject enemy;
    //Randomly chosen position
    public int randomPosition;
    //Randomly chosen speed
    public float randomSpeed;
    //Waittime between each spawn
    public float waitTime;




    // Start is called before the first frame update
    void Start()
    {
        //Start coroutine to start spawning
        StartCoroutine(WaitBeforeStart()); 
    }

    IEnumerator WaitBeforeStart()
    {
        //Wait 5 seconds before spawning process begins
        yield return new WaitForSeconds(5);
        //Store the children of this object, which are the spawnpoints
        StoreChildren();
        //Spawn enemy loop begins
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        //Choose random position
        randomPosition = Random.Range(0, 4);
        //Choose random speed
        randomSpeed = Random.Range(20f, 40f);
        //Instantiate an enemy on random chosen spawnpoint
        GameObject spawnedCar = Instantiate(enemy, spawnPoints[randomPosition].transform.position, Quaternion.identity);
        //Add a speed to the spawned car
        spawnedCar.GetComponent<EnemyController>().speed = randomSpeed;
        //Wait certain time before another spawn happens
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SpawnEnemy());
    }

    void StoreChildren()
    {
        foreach (Transform spawnpoint in transform)
        {
            //Store each spawnpoint in the list
            spawnPoints.Add(spawnpoint.gameObject);
        }
    }
}
