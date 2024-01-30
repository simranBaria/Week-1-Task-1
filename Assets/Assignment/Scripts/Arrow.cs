using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float turnSpeed = -150, shootSpeed = 2000, direction;
    bool shot = false;
    Rigidbody2D rigidbody;
    bool rotate = true;

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
        if (rotate)
        {
            // Rotate based on player input
            direction = Input.GetAxis("Horizontal");
            transform.Rotate(0, 0, direction * turnSpeed * Time.deltaTime);

            // Shoot if the player presses space and the targets are not displaying shooting order
            // This is to prevent the player from spamming targets while the game is trying to show them the correct order
            if (!GameObject.Find("Simon Says").GetComponent<SimonSays>().show)
            {
                if (Input.GetKeyDown(KeyCode.Space)) shot = true;
            }
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

        // Check if that was correct
        GameObject.Find("Simon Says").GetComponent<SimonSays>().CheckTarget(objectShot);
    }

    private void FixedUpdate()
    {
        // Only move if shot
        if(shot)
        {
            // Move the arrow
            Vector2 force = transform.right * shootSpeed * Time.deltaTime;
            rigidbody.AddForce(force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only rotate the arrow if it is on the bow trigger
        rotate = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // The arrow left the bow, do not rotate
        rotate = false;
    }
}
