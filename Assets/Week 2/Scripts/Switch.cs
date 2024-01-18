using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color myColour;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger from " + collision.gameObject);
        if (spriteRenderer != null) spriteRenderer.color = Color.red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (spriteRenderer != null) spriteRenderer.color = Color.green;
    }
}
