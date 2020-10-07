using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    public GameObject parent;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        //Parent object of collider which is the enemy car
        parent = transform.parent.gameObject;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //The store the object that collided
            player = other.gameObject;
            //Get the scripts that get impacted on colission
            PlayerController pc = player.GetComponent<PlayerController>();
            EnemyController ec = parent.GetComponent<EnemyController>();
            GameState gs = FindObjectOfType<GameState>();
            //Remove the physics constraints on hit
            RemoveConstraints(player);
            RemoveConstraints(parent);
            pc.SetControlable(false);
            //Call functions within impacted objects
            pc.HitByCar();
            ec.HitByCar();
            gs.SetHit();
        }

    }

    //Remove constraints
    void RemoveConstraints(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
