using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    List<int> lightOrder = new List<int>();
    int playerShots = 0;
    public GameObject red, yellow, green, blue, start, end;
    int current = 0, time = 120, counter = 0;
    public bool show = false;
    bool gameStart = false, gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        // Display the start UI and turn off the lose screen UI
        start.SetActive(true);
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game started
        if (gameStart) {
            // Show lights
            if (show)
            {
                // Wait until counter is zero so there is enough time between lights
                if (counter == 0)
                {
                    // Light up the current target
                    switch (lightOrder[current])
                    {
                        case 1:
                            red.GetComponent<Target>().TurnOn();
                            break;

                        case 2:
                            yellow.GetComponent<Target>().TurnOn();
                            break;

                        case 3:
                            green.GetComponent<Target>().TurnOn();
                            break;

                        case 4:
                            blue.GetComponent<Target>().TurnOn();
                            break;
                    }

                    // End the loop if all targets have been displayed
                    if (current != lightOrder.Count - 1) current++;
                    else show = false;

                    counter = time;
                }
                else counter--;
            }
        }
        else
        {
            // Check if the player lost
            if (Input.GetKeyDown(KeyCode.Space) && !gameEnd)
            {
                // End screen is not active
                // Turn off the start screen and start the game
                start.SetActive(false);
                StartGame();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && gameEnd)
            {
                // End screen is active
                // Turn it off and reset the game
                end.SetActive(false);
                ResetGame();
            }
        }
    }

    private void AddLight()
    {
        // Add a random colour next to the sequence
        lightOrder.Add(Random.Range(1, 4));
    }

    public void CheckTarget(int objectHit)
    {
        // Check if the player hit the right target
        if (objectHit == lightOrder[playerShots])
        {
            // Game continues
            playerShots++;
            GameObject.Find("Bow").GetComponent<Bow>().DrawArrow();
            CheckIfDone();
        }
        else EndGame();
    }


    private void NextSequence()
    {
        // Clear the shot order the player took
        playerShots = 0;

        // Add another light and show the next sequence
        AddLight();
        current = 0;
        show = true;

        // Increase player score
        GameObject.Find("Score").GetComponent<Score>().AddScore();
    }

    private void CheckIfDone()
    {
        // Check if the player has taken all the shots
        if (playerShots == lightOrder.Count) NextSequence();
    }

    private void EndGame()
    {
        // Player lost
        //print("player lost");
        end.SetActive(true);
        gameStart = false;
        gameEnd = true;
    }

    private void StartGame()
    {
        // Start the game
        gameStart = true;
        show = true;
        GameObject.Find("Bow").GetComponent<Bow>().DrawArrow();
        AddLight();
        counter = time;
    }

    private void ResetGame()
    {
        // Reset to scores and show start screen
        GameObject.Find("Score").GetComponent<Score>().ResetScore();
        start.SetActive(true);
        gameEnd = false;
        lightOrder.Clear();
        playerShots = 0;
        current = 0;
    }
}
