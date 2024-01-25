using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Oil : MonoBehaviour
{
    public float speedChange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject != null)
        {
            Debug.Log("Trigger from " + collision.gameObject);
            collision.attachedRigidbody.drag = speedChange;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject != null)
        {
            collision.attachedRigidbody.drag = 3;
        }
    }
}
