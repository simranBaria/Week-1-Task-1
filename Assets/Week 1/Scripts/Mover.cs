using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float speed = 5f;
    public GameObject missilePrefab;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Make missile appear
            Instantiate(missilePrefab, spawn.position, spawn.rotation);
        }
    }
}
