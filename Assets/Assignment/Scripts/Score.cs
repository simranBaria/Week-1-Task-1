using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[10];
    int score = 0;
    public GameObject firstDigit, secondDigit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        // Increase score
        score++;

        // Get the first digit using modulo 10
        // Get the second digit by subtracting from the score and dividing by 10
        int number = score % 10;
        SetScore((score - number) / 10, number);
    }

    public void ResetScore()
    {
        // Set the score to 0
        SetScore(0, 0);
        score = 0;
    }

    void SetScore(int digit1, int digit2)
    {
        // Set the sprites to represent the score
        firstDigit.GetComponent<SpriteRenderer>().sprite = sprites[digit1];
        secondDigit.GetComponent<SpriteRenderer>().sprite = sprites[digit2];
    }
}
