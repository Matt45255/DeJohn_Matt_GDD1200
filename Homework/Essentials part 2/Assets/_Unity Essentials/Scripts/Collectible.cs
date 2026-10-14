using UnityEngine;

public class Collectible : MonoBehaviour
{
    //Setting a variable for the rotation speed at 1 degree per frame
    public float rotationSpeed = 1.0f;
    public GameObject onCollecteffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //now we have no magic numbers and we can set the speed
        transform.Rotate(0, rotationSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Makes collisions only happen between the player and another object
        if (other.CompareTag("Player"))
        {
             //Destroys the collectible when player activates the trigger collider
        Destroy(gameObject);

        //Create an instance of the collectible effect when the collectible is collected
        Instantiate(onCollecteffect, transform.position, transform.rotation);
        }
       
    }
}
