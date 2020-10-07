using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Currentposition of car
    public Vector3 currentPosition;
    //The amount of horizontalMovement;
    public float horizontalInput;
    //The amount of verticalMovement
    public float verticalInput;
    //The movement speed
    public float speed = 100.0f;
    //Is player controlable
    public bool controlable;
    //Is player hit
    public bool hit;
    //Carobject that changes material on hit
    public GameObject CarObject;
    //The material used
    public Material hitMaterial;




    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //Check if controlable if so do movement
        if (controlable)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.position = new Vector3(transform.position.x + horizontalInput * Time.deltaTime * speed, transform.position.y, transform.position.z + verticalInput * Time.deltaTime * speed);
        }
        //Not controlable and hit: move backwards to simulate realism since the highway parts keep moving.
        else
        {
            if (hit)
            {
                transform.position = new Vector3(transform.position.x - 2 * Time.deltaTime * speed, transform.position.y + 0.5f * Time.deltaTime * speed, transform.position.z);
            }
           
        }
    }

    //Gets called by other parts of game, Set if player is controlable at this stage or not
    public void SetControlable(bool set)
    {
        controlable = set;
        hit = true;
    }

    // Gets called when collision with enemy car, set hitmaterial.
    public void HitByCar()
    {
        CarObject.GetComponent<MeshRenderer>().material = hitMaterial;
    }


        
    

   
}
