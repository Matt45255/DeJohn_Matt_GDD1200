using UnityEngine;

public class SpinPropellorX : MonoBehaviour
{

    private float spinspeed = 1440;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * spinspeed * Time.deltaTime);
    }
}
