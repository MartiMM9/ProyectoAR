using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles = new Vector3(270, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
