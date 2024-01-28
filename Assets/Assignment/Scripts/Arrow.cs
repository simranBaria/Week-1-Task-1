using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10;
    public bool shot = false;

    // Start is called before the first frame update
    void Start()
    {
        // Arrow should be rotated slightly to be aligned on the bow
        transform.Rotate(0, 0, -45);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(shot)
        {
            
        }
    }
}
