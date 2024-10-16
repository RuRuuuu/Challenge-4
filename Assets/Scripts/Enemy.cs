using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
         UnityEngine.Vector3  lookDirection = (player.transform.position - transform.position).normalized;
         //this is like the player location minus the enemy location to make the
    //the enemy always follow the player everywhere

    enemyRb.AddForce(lookDirection * speed);
          


          if (transform.position.y < -10)
          {
            Destroy(gameObject);
            
          }
        
    }
}
