﻿using System.Collections;
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

    public GameObject bullet;
    public float bulletForce;
    public float bulletLifeDestroyDelay;
    public float bulletOffsetFromPlayer;

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

        //check input from fire key and make bullets
        if (Input.GetButtonDown("Fire1")){
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + bulletOffsetFromPlayer, 0.0f);
            GameObject newBullet = Instantiate(bullet,bulletPosition,transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
            Destroy(newBullet,bulletLifeDestroyDelay);
        }


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
            newPos.x = screenRight;
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
