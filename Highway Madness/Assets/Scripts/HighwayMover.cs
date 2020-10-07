using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayMover : MonoBehaviour
{
    //Endlocation moving highway part
    public GameObject location;

    //Speed of the moving highway part.
    public float movementSpeed;


    // Update is called once per frame
    void Update()
    {
        //highway part moves over time towards the endpoint.
        transform.position = Vector3.MoveTowards(transform.position, location.transform.position, movementSpeed*Time.deltaTime);

        //reaches endpoint it destroys itself.
        if (transform.position.x <= location.transform.position.x)
        {
            Debug.Log("reached");
            Destroy(gameObject);
        }
    }
}
