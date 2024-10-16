using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour


{
    // Start is called before the first frame update
    public Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;

    private float powerUpStrength = 15.0f;

    private bool hasPowerUp = true;

    public GameObject powerUpIndicator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        //this means that we are referencing the game object called focal point on unity
        
    }

         //Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        //this means that we want to add force for our object to move anytime we click on the
        //vertical up and down key to move in the direction of the focal point game object

        //this means that adding the force to make it  move forward 
        //this 

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other){
        //this means that if the playerController triggers with the gameobject that has tag name  powerup
        //it should be destroy
        if (CompareTag("Powerup"))
        {

            hasPowerUp = false;
            powerUpIndicator.gameObject.SetActive(true);
          Destroy(other.gameObject);
          StartCoroutine(PowerUpCountdownRoutine());


        }
    }

    IEnumerator PowerUpCountdownRoutine(){
        yield return new WaitForSeconds(7);
         powerUpIndicator.gameObject.SetActive(true);
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision collision){
         if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
         {

            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("ok ");

            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            
         }

    }
}
