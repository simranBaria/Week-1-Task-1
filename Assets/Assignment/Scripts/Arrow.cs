using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float turnSpeed = 150;
    public float shootSpeed = 25;
    public bool shot = false;
    Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody component so the arrow collides with objects
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only rotate if not shot
        if (!shot)
        {
            float direction = Input.GetAxis("Horizontal");
            transform.Rotate(0, 0, direction * turnSpeed * Time.deltaTime);

            // Shoot if the player presses space
            if (Input.GetKeyDown(KeyCode.Space)) shot = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the arrow upon collision
        Destroy(gameObject);

        // Find what the arrow collided with
        int objectShot = 0;
        switch (collision.gameObject.ToString())
        {
            case "Red Target (UnityEngine.GameObject)":
                objectShot = 1;
                break;

            case "Yellow Target (UnityEngine.GameObject)":
                objectShot = 2;
                break;

            case "Green Target (UnityEngine.GameObject)":
                objectShot = 3;
                break;

            case "Blue Target (UnityEngine.GameObject)":
                objectShot = 4;
                break;

            case "Fence (UnityEngine.GameObject)":
                objectShot = 0;
                break;
        }

        // Add to the shot order
        GameObject.Find("Simon Says").GetComponent<SimonSays>().AddToOrder(objectShot);
    }

    private void FixedUpdate()
    {
        // Only move if shot
        if(shot)
        {
            // Shoot the arrow
            Vector2 direction = transform.right;
            rigidbody.MovePosition(rigidbody.position + direction * shootSpeed * Time.deltaTime);
        }
    }
}
