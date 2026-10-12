using UnityEngine;

public class Collectible : MonoBehaviour
{
    //Setting a variable for the rotation speed at 1 degree per frame
    public float rotationSpeed = 1.0f;
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
}
