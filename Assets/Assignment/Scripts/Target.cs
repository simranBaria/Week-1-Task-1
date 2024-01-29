using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Sprite defaultSprite, hitSprite;
    public bool on = true;
    public int time = 60;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        // Set the counter to the default time
        counter = time;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep the light on for a few frames so the player can see
        if (on) counter--;
        if(counter == 0)
        {
            TurnOff();
            counter = time;
        }

    }

    public void TurnOn()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprite;
        on = true;
    }

    public void TurnOff()
    {
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        on = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TurnOn();
    }
}
