using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect; // We are creating a game object named onCollectEffect

    // Update is called once per frame
    void Update()
    {
        // Rotates on the z axis, by .5f
        transform.Rotate(0, 0, rotationSpeed);
        
    }
    // We triggered a collider incident
    // Returns nothing! basically just an update method which changes things on collision
    private void OnTriggerEnter2D(Collider2D other) {
        
         // Check if the other object has a PlayerController2D component
         // Really easy way to check to make sure the other object is the player, and not a piece of furnature or something else
        if (other.GetComponent<PlayerController2D>() != null) {
            
            // Destroy the collectible
            // Destroyed, gone but not forgotten
            Destroy(gameObject);

            // Instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }

        
    }


}


