using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    List<int> lightOrder = new List<int>();
    public int playerShots = 0;
    public GameObject red, yellow, green, blue, start, end;
    int current = 0, time = 120, counter = 0;
    bool show = false, gameStart = false, gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        // Display the start UI
        start.SetActive(true);
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
            if (Input.GetKeyDown(KeyCode.Space) && !gameEnd)
            {
                start.SetActive(false);
                StartGame();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && gameEnd)
            {
                end.SetActive(false);
                ResetGame();
            }
        }
    }

    private void AddLights()
    {
        // Add a random colour next to the sequence
        lightOrder.Add(Random.Range(1, 4));
    }

    public void AddToOrder(int objectHit)
    {
        // Check if the player hit the right target
        if (objectHit == lightOrder[playerShots])
        {
            //print("correct");
            playerShots++;
            GameObject.Find("Bow").GetComponent<Bow>().DrawArrow();
            CheckIfDone();
        }
        else
        {
            //print("player missed");
            EndGame();
        }
    }


    private void NextSequence()
    {
        // Clear the shot order the player took
        playerShots = 0;

        // Add another light
        AddLights();
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
        GameObject.Find("Bow").GetComponent<Bow>().pause = true;
        gameStart = false;
        gameEnd = true;
    }

    private void StartGame()
    {
        // Start the game
        gameStart = true;
        show = true;
        GameObject.Find("Bow").GetComponent<Bow>().pause = false;
        GameObject.Find("Bow").GetComponent<Bow>().DrawArrow();
        AddLights();
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
