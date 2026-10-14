using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the vehicle forward
        //Deltatime is based on the difference in time between the current and previous frame.
        //If we have a 0 second difference between frames, we are good
        //if there is a discrepency, we need to compensate
        //We do this because hardware is extremely inconsistent
        transform.Translate(Vector3.forward * Time.deltaTime * 20);
        
    }
}
