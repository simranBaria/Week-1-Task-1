using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Sprite defaultSprite, hitSprite;
    bool on = false;
    int time = 60, counter;

    // Start is called before the first frame update
    void Start()
    {
        // Set the counter to the default time
        counter = time;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep the target on for a few frames so the player can see
        if (on) counter--;
        if (counter == 0)
        {
            // Change back to default sprite once counter reaches 0
            TurnOff();

            // Reset counter
            counter = time;
        }
    }

    public void TurnOn()
    {
        // Change sprite to hit
        GetComponent<SpriteRenderer>().sprite = hitSprite;
        on = true;
    }

    public void TurnOff()
    {
        // Change sprite to default
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        on = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Turn the target on when hit
        TurnOn();
    }
}
