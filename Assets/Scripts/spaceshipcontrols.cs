using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipcontrols : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;

//Screen maximums
    public float screenTop;
    public float screenBottom;
    public float screenRight;
    public float screenLeft;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get input from keyboard and apply thrust
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");   

        //screen wrapping
        Vector2 newPos =  transform.position;

        //begin if changes 
        if(transform.position.y > screenTop){
            newPos.y = screenBottom;
        }
        if(transform.position.y < screenBottom){
            newPos.y = screenTop;
        }
    
        if(transform.position.x > screenRight){
            newPos.x = screenLeft;
        }
        if(transform.position.x < screenLeft){
            newPos.y = screenRight;
        }

        //set it back
        transform.position = newPos;
    }

    //Fixed timeing update
    void FixedUpdate() {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        rb.AddTorque(-turnInput);
    }
}
