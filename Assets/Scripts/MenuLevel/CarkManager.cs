using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarkManager : MonoBehaviour
{
    public int speed = 30;

    // Start is called before the first frame update
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate( Vector3.forward * speed * Time.deltaTime );
    }
}
