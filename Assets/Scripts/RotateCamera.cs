using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update

   public float rotateSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //this meaning left and right arrow keys
         transform.Rotate(Vector3.up, horizontalInput* rotateSpeed* Time.deltaTime);
    }
}
