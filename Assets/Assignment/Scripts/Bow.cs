using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    float speed = -150;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates bow based on player input
        float direction = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, direction * speed * Time.deltaTime);
    }

    public void DrawArrow()
    {
        // Make an arrow appear on the bow
        Instantiate(arrow, transform.position, transform.rotation);
    }
}
