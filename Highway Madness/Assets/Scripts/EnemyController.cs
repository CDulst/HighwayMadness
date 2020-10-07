using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //List of possible cars that could get displayed within enemy
    public List<GameObject> cars;
    //How fast will the car go
    public float speed;
    //Car that gets randomly chosen
    public GameObject car;
    //Material that gets used on hit.
    public Material hitMaterial;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShredEnemy());
        //Get a random car of the stored ones
        int random = Random.Range(0, cars.Count);
        //Instantiate the random car as child of the enemy
        car = Instantiate(cars[random], transform.position, Quaternion.identity);

        //Transform the car on start
        car.transform.parent = gameObject.transform;
        car.transform.Rotate(0f, -90f,0f);
        car.transform.localScale = new Vector3(1.1226f, 1.1226f, 1.1226f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    //Destroy instance of enemy after that many seconds
    IEnumerator ShredEnemy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }


    //Function called after collision with player car

    public void HitByCar()
    {
        GameObject carPiece = car.transform.GetChild(0).gameObject;
        carPiece.GetComponent<MeshRenderer>().material = hitMaterial;
    }

}
